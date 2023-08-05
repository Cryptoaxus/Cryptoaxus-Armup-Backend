namespace CryptoAxus.Domain.Collections;

[BsonCollection("NftCollections")]
public class NftCollectionsDocument : BaseDocument
{
    [BsonElement(elementName: "collectionLogoImageHash", Order = 2)]
    public string CollectionLogoImageHash { get; set; }

    [BsonElement(elementName: "collectionFeaturedImageHash", Order = 3)]
    public string CollectionFeaturedImageHash { get; set; }

    [BsonElement(elementName: "collectionBannerImageHash", Order = 4)]
    public string CollectionBannerImageHash { get; set; }

    [BsonElement(elementName: "collectionName", Order = 5)]
    public string CollectionName { get; set; }

    [BsonElement(elementName: "artistWalletAddress", Order = 6)]
    public string ArtistWalletAddress { get; set; }

    [BsonElement(elementName: "url", Order = 7)]
    public string Url { get; set; }

    [BsonElement(elementName: "description", Order = 8)]
    public string Description { get; set; }

    [BsonElement(elementName: "category", Order = 9)]
    public string Category { get; set; }

    [BsonElement(elementName: "collectionBlockChain", Order = 10)]
    public string CollectionBlockChain { get; set; }

    [BsonElement(elementName: "explicitContent", Order = 13)]
    public bool ExplicitContent { get; set; }

    public NftCollectionsDocument() : base()
    {
    }

    public NftCollectionsDocument(ObjectId id,
                                   string collectionLogoImageHash,
                                   string collectionFeaturedImageHash,
                                   string collectionBannerImageHash,
                                   string collectionName,
                                   string artistWalletAddress,
                                   string url,
                                   string description,
                                   string category,
                                   string collectionBlockChain,
                                   bool explicitContent,
                                   string createdBy,
                                   DateTime? lastModifiedDate = null,
                                   string? lastModifiedBy = null,
                                   string? lastUpdated = null,
                                   bool isDeleted = false)
                                   : base(id,
                                         createdBy,
                                         lastModifiedDate,
                                         lastModifiedBy,
                                         isDeleted)
    {
        Id = id;
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
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}

