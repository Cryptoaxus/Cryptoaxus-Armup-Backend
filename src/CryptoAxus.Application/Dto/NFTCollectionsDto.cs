namespace CryptoAxus.Application.Dto;

public class NFTCollectionstDto : BaseDto
{
    public string? CollectionLogoImageHash { get; set; }


    public string? CollectionFeaturedImageHash { get; set; }

    public string? CollectionBannerImageHash { get; set; }

    public string? CollectionName { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? CollectionBlockChain { get; set; }

    public bool? ExplicitContent { get; set; }

    public NFTCollectionstDto()
    {
    }
}