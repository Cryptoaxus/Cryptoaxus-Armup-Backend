namespace CryptoAxus.Application.Contracts.Repositories;

public interface IRepository<TDocument> where TDocument : IBaseDocument
{
    Task<long> CountAsync(Expression<Func<TDocument, bool>>? filterExpression, CancellationToken cancellationToken);

    IQueryable<TDocument> AsQueryable();

    Task<bool> Exists(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default);

    Task<List<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression,
                                        int? pageNumber = null,
                                        int? pageSize = null,
                                        CancellationToken cancellationToken = default);

    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression,
                                 CancellationToken cancellationToken = default);

    Task<TDocument> FindByIdAsync(ObjectId id);

    Task InsertOneAsync(TDocument document);

    Task InsertManyAsync(ICollection<TDocument> documents);

    Task ReplaceOneAsync(TDocument document);

    Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filterExpression, UpdateDefinition<TDocument> updateExpression);

    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    Task<DeleteResult> DeleteByIdAsync(ObjectId id);

    Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
}