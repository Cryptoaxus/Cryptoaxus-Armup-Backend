namespace CryptoAxus.Application.Dto;

public class FavoriteNftsDto : BaseDto
{
    public string? NftId { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? CollectionId { get; set; }

    public FavoriteNftsDto() : base()
    {
    }
    public FavoriteNftsDto(ObjectId? id = null,
                           string? nftId = null,
                           string? artistWalletAddress = null,
                           string? collectionId = null)
    {

        Id = id;
        NftId = nftId;
        ArtistWalletAddress = artistWalletAddress;
        CollectionId = collectionId;
    }
}
