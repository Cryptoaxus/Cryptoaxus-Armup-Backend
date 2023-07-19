namespace CryptoAxus.Infrastructure.Implementation.Repositories;

public class Repository<TDocument> : IRepository<TDocument> where TDocument : IBaseDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    public Repository(ICryptoAxusContext context)
    {
        ArgumentException.ThrowIfNullOrEmpty(context.ToString(), nameof(context));

        _collection = context.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    public Task<long> CountAsync(Expression<Func<TDocument, bool>>? filterExpression, CancellationToken cancellationToken)
    {
        return _collection.CountDocumentsAsync(filter: filterExpression, cancellationToken: cancellationToken);
    }

    public IQueryable<TDocument> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public Task<bool> Exists(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
    {
        return Task.Run(function: () => _collection.AsQueryable()
                                                   .AnyAsync(filterExpression, cancellationToken), cancellationToken);
    }

    public Task<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression,
                                          int? pageNumber = null,
                                          int? pageSize = null,
                                          CancellationToken cancellationToken = default)
    {
        if (pageNumber is not null && pageSize is not null)
            return Task.Run(function: () => _collection.Find(filterExpression)
                                                       .Skip((pageNumber - 1) * pageSize)
                                                       .Limit(pageSize)
                                                       .ToListAsync());

        return Task.Run(function: () => _collection.Find(filterExpression)
                                                   .ToListAsync());
    }

    public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
                                                        Expression<Func<TDocument, TProjected>> projectionExpression)
    {
        return _collection.Find(filterExpression)
                          .Project(projectionExpression)
                          .ToEnumerable();
    }

    public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).FirstOrDefault();
    }

    public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression,
                                        CancellationToken cancellationToken = default)
    {
        return Task.Run(function: () => _collection.Find(filterExpression).FirstOrDefaultAsync(cancellationToken), cancellationToken);
    }

    public TDocument FindById(ObjectId id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        return _collection.Find(filter).SingleOrDefault();
    }

    public Task<TDocument> FindByIdAsync(ObjectId id)
    {
        return Task.Run(function: () =>
        {
            var filter = Builders<TDocument>.Filter.Eq(field: doc => doc.Id, value: id);
            return _collection.Find(filter: filter).SingleOrDefaultAsync();
        });
    }

    public void InsertOne(TDocument document)
    {
        _collection.InsertOne(document);
    }

    public Task InsertOneAsync(TDocument document)
    {
        return _collection.InsertOneAsync(document);
    }

    public void InsertMany(ICollection<TDocument> documents)
    {
        _collection.InsertMany(documents);
    }

    public async Task InsertManyAsync(ICollection<TDocument> documents)
    {
        await _collection.InsertManyAsync(documents);
    }

    public void ReplaceOne(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        _collection.FindOneAndReplace(filter, document);
    }

    public async Task ReplaceOneAsync(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        await _collection.FindOneAndReplaceAsync(filter, document);
    }

    public async Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filterExpression, UpdateDefinition<TDocument> updateExpression)
    {
        return await _collection.UpdateOneAsync(filterExpression, updateExpression);
    }

    public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.FindOneAndDelete(filterExpression);
    }

    public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
    }

    public void DeleteById(ObjectId id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        _collection.FindOneAndDelete(filter);
    }

    public Task<DeleteResult> DeleteByIdAsync(ObjectId id)
    {
        return Task.Run(function: () => _collection.DeleteOneAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, id)));
    }

    public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.DeleteMany(filterExpression);
    }

    public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
    }

    private string? GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType
                                         .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                                         .FirstOrDefault()!)?.CollectionName;
    }
}