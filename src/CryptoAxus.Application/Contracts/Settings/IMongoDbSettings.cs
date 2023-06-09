namespace CryptoAxus.Application.Contracts.Settings;

public interface IMongoDbSettings
{
    string ConnectionString { get; }

    string DatabaseName { get; }
}