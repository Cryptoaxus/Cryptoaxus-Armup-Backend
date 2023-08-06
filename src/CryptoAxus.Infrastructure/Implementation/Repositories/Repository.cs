namespace CryptoAxus.Infrastructure.Implementation.Repositories;

public class Repository<TDocument> : IRepository<TDocument> where TDocument : IBaseDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    public Repository(ICryptoAxusContext context)
    {
        ArgumentException.ThrowIfNullOrEmpty(context.ToString(), nameof(context));

        _collection = context.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    public Task<long> CountAsync(Expression<Func<TDocument, bool>>? filterExpression,
                                 CancellationToken cancellationToken)
        => _collection.CountDocumentsAsync(filter: filterExpression, cancellationToken: cancellationToken);

    public IQueryable<TDocument> AsQueryable()
        => _collection.AsQueryable();

    public Task<bool> Exists(Expression<Func<TDocument, bool>> filterExpression,
                             CancellationToken cancellationToken = default)
        => _collection.AsQueryable()
                      .AnyAsync(filterExpression, cancellationToken);

    public Task<List<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression,
                                               int? pageNumber = null,
                                               int? pageSize = null,
                                               CancellationToken cancellationToken = default)
    {
        if (pageNumber is not null && pageSize is not null)
            return _collection.Find(filterExpression)
                              .Skip((pageNumber - 1) * pageSize)
                              .Limit(pageSize)
                              .ToListAsync(cancellationToken);

        return _collection.Find(filterExpression)
                          .ToListAsync(cancellationToken);
    }

    public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression,
                                        CancellationToken cancellationToken = default)
        => _collection.Find(filterExpression)
                      .FirstOrDefaultAsync(cancellationToken);

    public Task<TDocument> FindByIdAsync(ObjectId id)
        => _collection.Find(Builders<TDocument>.Filter.Eq(doc => doc.Id, id))
                      .SingleOrDefaultAsync();

    public Task InsertOneAsync(TDocument document) => _collection.InsertOneAsync(document);

    public Task InsertManyAsync(ICollection<TDocument> documents) => _collection.InsertManyAsync(documents);

    public Task ReplaceOneAsync(TDocument document)
        => _collection.FindOneAndReplaceAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id), document);

    public Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filterExpression,
                                             UpdateDefinition<TDocument> updateExpression)
        => _collection.UpdateOneAsync(filterExpression, updateExpression);

    public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        => _collection.FindOneAndDeleteAsync(filterExpression);

    public Task<DeleteResult> DeleteByIdAsync(ObjectId id)
        => _collection.DeleteOneAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, id));

    public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        => _collection.DeleteManyAsync(filterExpression);

    private string? GetCollectionName(Type documentType)
        => ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                                                 .FirstOrDefault()!)?.CollectionName;
}