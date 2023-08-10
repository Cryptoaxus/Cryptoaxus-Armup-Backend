namespace CryptoAxus.Application.Dto.Nft;

public class UpdateNftCollectionDto
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

    public string? LastModifiedBy { get; set; }

    public UpdateNftCollectionDto(string? collectionLogoImageHash = null,
                                  string? collectionFeaturedImageHash = null,
                                  string? collectionBannerImageHash = null,
                                  string? collectionName = null,
                                  string? artistWalletAddress = null,
                                  string? url = null,
                                  string? description = null,
                                  string? category = null,
                                  string? collectionBlockChain = null,
                                  bool explicitContent = false,
                                  string? lastModifiedBy = null)
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
        LastModifiedBy = lastModifiedBy;
    }
}