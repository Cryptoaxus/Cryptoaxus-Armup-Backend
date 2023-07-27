namespace CryptoAxus.Infrastructure.Context;

public class CryptoAxusContext : ICryptoAxusContext
{
    private IMongoDatabase Database { get; set; }
    private MongoClient MongoClient { get; set; }
    public IClientSessionHandle Session { get; set; }

    public CryptoAxusContext(IMongoDbSettings settings)
    {
        MongoClient = new MongoClient(settings.ConnectionString);
        Database = MongoClient.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string? collectionName)
    {
        return Database.GetCollection<T>(collectionName);
    }
}