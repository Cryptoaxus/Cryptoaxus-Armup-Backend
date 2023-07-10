namespace CryptoAxus.Application.Contracts.Repositories;

public interface IRepository<TDocument> where TDocument : IBaseDocument
{
    Task<long> CountAsync(Expression<Func<TDocument, bool>>? filterExpression, CancellationToken cancellationToken);

    IQueryable<TDocument> AsQueryable();

    Task<bool> Exists(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default);

    Task<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression,
                                   int? pageNumber = null,
                                   int? pageSize = null,
                                   CancellationToken cancellationToken = default);
 
    IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression,
                                                 Expression<Func<TDocument, TProjected>> projectionExpression);

    TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression,
                                 CancellationToken cancellationToken = default);

    TDocument FindById(ObjectId id);

    Task<TDocument> FindByIdAsync(ObjectId id);

    void InsertOne(TDocument document);

    Task InsertOneAsync(TDocument document);

    void InsertMany(ICollection<TDocument> documents);

    Task InsertManyAsync(ICollection<TDocument> documents);

    void ReplaceOne(TDocument document);

    Task ReplaceOneAsync(TDocument document);

    Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filterExpression, UpdateDefinition<TDocument> updateExpression);

    void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    void DeleteById(ObjectId id);

    Task<DeleteResult> DeleteByIdAsync(ObjectId id);

    void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
}