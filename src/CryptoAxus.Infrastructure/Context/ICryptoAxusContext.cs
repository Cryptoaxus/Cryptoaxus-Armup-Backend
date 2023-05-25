namespace CryptoAxus.Infrastructure.Context;

public interface ICryptoAxusContext
{
    IMongoCollection<ArtistDocument> GetCollection<ArtistDocument>(string? collectionName);

}