namespace CryptoAxus.Application.Dto.Nft;

public class NftDto : BaseDto
{
    public string? ContractAddress { get; set; }

    public string? Hash { get; set; }

    public string? ImageStorageLink { get; set; }

    public string? Signature { get; set; }

    public int? TokenId { get; set; }

    public int? Quantity { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public string? Collection { get; set; }

    public ObjectId? CollectionId { get; set; }

    public string? BlockChain { get; set; }

    public int? CreatorEarnings { get; set; }

    public List<string>? Favorites { get; set; }

    public List<string>? Likes { get; set; }

    public NftDto() : base()
    {
    }

    public NftDto(ObjectId id,
                  string? contractAddress = null,
                  string? hash = null,
                  string? imageStorageLink = null,
                  string? signature = null,
                  int? tokenId = null,
                  int? quantity = null,
                  string? name = null,
                  string? url = null,
                  string? description = null,
                  string? collection = null,
                  ObjectId? collectionId = null,
                  string? blockChain = null,
                  int? creatorEarnings = null,
                  ObjectId? createdBy = null,
                  DateTime? lastModifiedDate = null,
                  ObjectId? lastModifiedBy = null,
                  bool isDeleted = false) :
                  base(id,
                       createdBy,
                       lastModifiedDate,
                       lastModifiedBy,
                       isDeleted)
    {
        ContractAddress = contractAddress;
        Hash = hash;
        ImageStorageLink = imageStorageLink;
        Signature = signature;
        TokenId = tokenId;
        Quantity = quantity;
        Name = name;
        Url = url;
        Description = description;
        Collection = collection;
        CollectionId = collectionId;
        BlockChain = blockChain;
        CreatorEarnings = creatorEarnings;
    }
}