namespace CryptoAxus.Application.Dto.Nft;

public class CreateNftCollectionsDto
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

    public string CreatedBy { get; set; }

    public CreateNftCollectionsDto(string? collectionLogoImageHash,
                                   string? collectionFeaturedImageHash,
                                   string? collectionBannerImageHash,
                                   string? collectionName,
                                   string? artistWalletAddress,
                                   string? url,
                                   string? description,
                                   string? category,
                                   string? collectionBlockChain,
                                   bool explicitContent,
                                   string createdBy)
    {
        CollectionLogoImageHash = collectionLogoImageHash;
        CollectionFeaturedImageHash = collectionFeaturedImageHash;
        CollectionBannerImageHash = collectionBannerImageHash;
        CollectionName = collectionName;
        ArtistWalletAddress = artistWalletAddress;
        Url = url;
        Description = description;
        Category = category;
        CollectionBlockChain = collectionBlockChain;
        ExplicitContent = explicitContent;
        CreatedBy = createdBy;
    }
}