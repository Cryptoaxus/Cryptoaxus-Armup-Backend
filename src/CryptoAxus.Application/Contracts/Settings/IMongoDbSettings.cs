namespace CryptoAxus.Application.Contracts.Settings;

public interface IMongoDbSettings
{
    string DatabaseName { get; }
    string ConnectionString { get; }
}