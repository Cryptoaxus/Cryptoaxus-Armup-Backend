using Microsoft.Extensions.Options;

namespace CryptoAxus.Infrastructure.Context;

public class CryptoAxusContext : ICryptoAxusContext
{
    private IMongoDatabase _database { get; set; }
    private MongoClient _mongoClient { get; set; }
    public IClientSessionHandle Session { get; set; }

    public CryptoAxusContext(IOptions<MongoDbSettings> settings)
    {
        _mongoClient = new MongoClient(settings.Value.ConnectionString);
        _database = _mongoClient.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string? collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}