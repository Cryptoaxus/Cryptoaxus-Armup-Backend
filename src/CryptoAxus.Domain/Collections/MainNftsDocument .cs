namespace CryptoAxus.Domain.Collections;

[BsonCollection("MainNfts")]
public class MainNftsDocument : BaseDocument
{
    [BsonElement(elementName: "contractAddress", Order = 2)]
    public string ContractAddress { get; set; }

    [BsonElement(elementName: "hash", Order = 3)]
    public string Hash { get; set; }

    [BsonElement(elementName: "imageStoragelink", Order = 4)]
    public string ImageStoragelink { get; set; }

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

    [BsonElement(elementName: "blockchain", Order = 13)]
    public string Blockchain { get; set; }

    [BsonElement(elementName: "createrEarnings", Order = 14)]
    public int CreaterEarnings { get; set; }
 
    public MainNftsDocument() : base()
   
    {
    }

    public MainNftsDocument(ObjectId id,
                            string contractAddress,
                            string hash,
                            string imageStoragelink,
                            int tokenId,
                            int quantity,
                            string name,
                            string url,
                            string description,
                            string collection,
                            string collectionId,
                            string blockchain,
                            int createrEarnings,
                            ObjectId createdBy,
                            DateTime? lastModifiedDate = null,
                            ObjectId? lastModifiedBy = null,
                            string? signature = null,
                            bool isDeleted = false)
                            :base(id,
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