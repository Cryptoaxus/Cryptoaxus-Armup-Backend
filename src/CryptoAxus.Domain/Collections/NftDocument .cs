namespace CryptoAxus.Domain.Collections;

[BsonCollection("Nft")]
public class NftDocument : BaseDocument
{
    [BsonElement(elementName: "contractAddress", Order = 2)]
    public string ContractAddress { get; set; }

    [BsonElement(elementName: "hash", Order = 3)]
    public string Hash { get; set; }

    [BsonElement(elementName: "imageStorageLink", Order = 4)]
    public string ImageStorageLink { get; set; }

    [BsonElement(elementName: "signature", Order = 5)]
    public string? Signature { get; set; }

    [BsonElement(elementName: "tokenId", Order = 6)]
    public int TokenId { get; set; }

    [BsonElement(elementName: "quantity", Order = 7)]
    public int Quantity { get; set; }

    [BsonElement(elementName: "name", Order = 8)]
    public string Name { get; set; }

    [BsonElement(elementName: "url", Order = 9)]
    public string Url { get; set; }

    [BsonElement(elementName: "description", Order = 10)]
    public string Description { get; set; }

    [BsonElement(elementName: "collection", Order = 11)]
    public string Collection { get; set; }

    [BsonElement(elementName: "collectionId", Order = 12)]
    public string CollectionId { get; set; }

    [BsonElement(elementName: "blockChain", Order = 13)]
    public string BlockChain { get; set; }

    [BsonElement(elementName: "creatorEarnings", Order = 14)]
    public int CreatorEarnings { get; set; }

    public NftDocument() : base()
    {
    }

    public NftDocument(ObjectId id,
                       string contractAddress,
                       string hash,
                       string imageStorageLink,
                       int tokenId,
                       int quantity,
                       string name,
                       string url,
                       string description,
                       string collection,
                       string collectionId,
                       string blockChain,
                       int creatorEarnings,
                       string? signature,
                       ObjectId createdBy,
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
        Signature = signature;
    }
}