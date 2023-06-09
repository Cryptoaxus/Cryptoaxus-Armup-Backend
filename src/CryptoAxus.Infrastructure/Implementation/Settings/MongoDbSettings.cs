namespace CryptoAxus.Infrastructure.Implementation.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }


    public MongoDbSettings()
    {
    }

    public MongoDbSettings(string databaseName, string connectionString) => (DatabaseName, ConnectionString) = (databaseName, connectionString);
}