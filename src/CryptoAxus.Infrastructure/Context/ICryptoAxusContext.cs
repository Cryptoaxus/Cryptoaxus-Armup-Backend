namespace CryptoAxus.Infrastructure.Context;

public interface ICryptoAxusContext
{
    IMongoCollection<T> GetCollection<T>(string? collectionName);
}