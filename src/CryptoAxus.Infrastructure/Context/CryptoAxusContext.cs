namespace CryptoAxus.Infrastructure.Context;

public class CryptoAxusContext : ICryptoAxusContext
{
    private IMongoDatabase _database { get; set; }
    private MongoClient _mongoClient { get; set; }
    public IClientSessionHandle Session { get; set; }

    public CryptoAxusContext(IMongoDbSettings settings)
    {
        _mongoClient = new MongoClient(settings.ConnectionString);
        _database = _mongoClient.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string? collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}