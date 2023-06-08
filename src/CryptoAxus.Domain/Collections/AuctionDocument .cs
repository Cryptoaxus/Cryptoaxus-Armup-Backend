namespace CryptoAxus.Domain.Collections;

[BsonCollection("Auction")]
public class AuctionDocument : BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "nftCopyId", Order = 3)]
    public string NftCopyId { get; set; }

    [BsonElement(elementName: "quantity", Order = 4)]
    public int Quantity{ get; set; }

    [BsonElement(elementName: "minimumBid", Order = 5)]
    public decimal MinimumBid { get; set; }

    [BsonElement(elementName: "softDelete", Order = 6)]
    public bool SoftDelete { get; set; }

    [BsonElement(elementName: "startingDateTime", Order = 7)]
    public DateTime StartingDateTime { get; set; }
    
    [BsonElement(elementName: "endingDateTime", Order = 8)]
    public DateTime EndingDateTime { get; set; } 
    
    public AuctionDocument() : base()
    {
    }

    public AuctionDocument(ObjectId id, 
                           string nftId,
                           string nftCopyId,
                           int quantity,
                           decimal minimumBid,
                           bool softDelete,
                           DateTime startingDateTime,
                           DateTime endingDateTime,
                           ObjectId createdBy,
                           DateTime? lastModifiedDate = null,
                           ObjectId? lastModifiedBy = null,
                           DateTime? deleted_at = null,
                           bool isDeleted = false)
                           : base(id,
                                 createdBy,
                                 lastModifiedDate,
                                 lastModifiedBy)
    {
        Id = id;
        NftId = nftId;
        NftCopyId = nftCopyId;
        Quantity = quantity;
        MinimumBid = minimumBid;
        SoftDelete = softDelete;
        StartingDateTime = startingDateTime;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}

