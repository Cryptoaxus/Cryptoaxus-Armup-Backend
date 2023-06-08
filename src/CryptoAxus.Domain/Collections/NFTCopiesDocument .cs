namespace CryptoAxus.Domain.Collections;

[BsonCollection("NFTCopies")]
public class NFTCopiesDocument : BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "owner", Order = 3)]
    public string Owner { get; set; }

    [BsonElement(elementName: "ownerName", Order = 4)]
    public string OwnerName { get; set; }

    [BsonElement(elementName: "quantity", Order = 5)]
    public int Quantity { get; set; }

    [BsonElement(elementName: "isCreator", Order = 6)]
    public bool IsCreator { get; set; }

    [BsonElement(elementName: "marketTokenId", Order = 7)]
    public int MarketTokenId { get; set; }

    public NFTCopiesDocument() : base()
    {
    }

    public NFTCopiesDocument(ObjectId id, 
                             string nftId,
                             string owner,
                             string ownerName,
                             int quantity,
                             bool isCreator,
                             int marketTokenId,
                             string bidderUserName,
                             ObjectId createdBy,
                             DateTime? lastModifiedDate = null,
                             ObjectId? lastModifiedBy = null,
                             bool isDeleted = false)
                             : base(id,
                                    createdBy,
                                    lastModifiedDate,
                                    lastModifiedBy,
                                    isDeleted )
    {
        Id = id;
        NftId = nftId;
        Owner = owner;
        Quantity = quantity;
        IsCreator = isCreator;
        MarketTokenId = marketTokenId;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}



