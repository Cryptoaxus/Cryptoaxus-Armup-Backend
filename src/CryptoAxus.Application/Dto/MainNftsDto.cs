namespace CryptoAxus.Application.Dto;

public class MainNftsDto : BaseDto
{
    public string? ContractAddress { get; set; }

    public string? Hash { get; set; }

    public string? ImageStoragelink { get; set; }

    public string? Signature { get; set; }

    public int? TokenId { get; set; }

    public int? Quantity { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public string? Collection { get; set; }

    public string? CollectionId { get; set; }

    public string? Blockchain { get; set; }

    public int? CreaterEarnings { get; set; }

    public MainNftsDto() : base()
    {
    }

    public MainNftsDto(ObjectId id,
                       string? contractAddress = null,
                       string? hash = null,
                       string? imageStoragelink = null,
                       int? tokenId = null,
                       int? quantity = null,
                       string? name = null,
                       string? url = null,
                       string? description = null,
                       string? collection = null,
                       string? collectionId = null,
                       string? blockchain = null,
                       int? createrEarnings = null,
                       ObjectId? createdBy = null,
                       DateTime? lastModifiedDate = null,
                       ObjectId? lastModifiedBy = null,
                       string? signature = null,
                       bool isDeleted = false)
                       : base(id,
                              createdBy,
                              lastModifiedDate,
                              lastModifiedBy,
                              isDeleted)
    {
        Id = id;
        ContractAddress = contractAddress;
        Hash = hash;
        ImageStoragelink = imageStoragelink;
        Signature = signature;
        TokenId = tokenId;
        Quantity = quantity;
        Name = name;
        Url = url;
        Description = description;
        Collection = collection;
        CollectionId = collectionId;
        Blockchain = blockchain;
        CreaterEarnings = createrEarnings;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}