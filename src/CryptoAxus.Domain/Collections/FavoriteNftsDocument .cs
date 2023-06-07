namespace CryptoAxus.Domain.Collections;

[BsonCollection("FavoriteNfts")]
public class FavoriteNftsDocument : BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "artistWalletAddress", Order = 3)]
    public string ArtistWalletAddress { get; set; }

    [BsonElement(elementName: "collectionId", Order = 4)]
    public string CollectionId { get; set; }
    
    public FavoriteNftsDocument() : base()
    {
    }

    public FavoriteNftsDocument(ObjectId id,
                          string nftId,
                          string artistWalletAddress,
                          string collectionId)
    {

        Id = id;
        NftId = nftId;
        ArtistWalletAddress = artistWalletAddress;
        CollectionId = collectionId;
       

    }
}
