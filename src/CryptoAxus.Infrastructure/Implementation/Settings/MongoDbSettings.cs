namespace CryptoAxus.Infrastructure.Implementation.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; private set; }
    public string ConnectionString { get; private set; }

    public MongoDbSettings()
    {
    }

    public MongoDbSettings(string databaseName, string connectionString) => (DatabaseName, ConnectionString) = (databaseName, connectionString);
}