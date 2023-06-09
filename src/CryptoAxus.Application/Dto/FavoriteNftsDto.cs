namespace CryptoAxus.Application.Dto;

public class FavoriteNftsDto : BaseDto
{
    public string? NftId { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? CollectionId { get; set; }

    public FavoriteNftsDto()
    {
    }
}