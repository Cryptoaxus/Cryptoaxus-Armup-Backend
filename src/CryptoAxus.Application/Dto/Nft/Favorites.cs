namespace CryptoAxus.Application.Dto.Nft;

public class Favorites
{
    public int ArtistId { get; set; }

    public ObjectId CollectionId { get; set; }

    public Favorites(int artistId, ObjectId collectionId) => (ArtistId, CollectionId) = (artistId, collectionId);
}