namespace CryptoAxus.Domain.Collections;

[BsonCollection("FixedPriced")]
public class FixedPricedDocument : BaseDocument
{
    [BsonElement(elementName: "nftCopyId", Order = 2)]
    public string NftCopyId { get; set; }

    [BsonElement(elementName: "quantity", Order = 3)]
    public int Quantity { get; set; }

    [BsonElement(elementName: "pricePerItem", Order = 4)]
    public decimal PricePerItem { get; set; }

    [BsonElement(elementName: "fixedEndingDateTime", Order = 5)]
    public DateTime FixedEndingDateTime { get; set; }

    [BsonElement(elementName: "softDelete", Order = 7)]
    public bool SoftDelete { get; set; }

    public FixedPricedDocument() : base()
    {
    }

    public FixedPricedDocument(ObjectId id,
                               string nftCopyId,
                               int quantity,
                               decimal pricePerItem,
                               DateTime fixedEndingDateTime,
                               bool softDelete,
                               ObjectId createdBy,
                               DateTime? lastModifiedDate = null,
                               ObjectId? lastModifiedBy = null,
                               bool isDeleted = false)
                               : base(id,
                                     createdBy,
                                     lastModifiedDate,
                                     lastModifiedBy,
                                     isDeleted)
    {

        Id = id;
        NftCopyId = nftCopyId;
        Quantity = quantity;
        PricePerItem = pricePerItem;
        FixedEndingDateTime = fixedEndingDateTime;
        SoftDelete = softDelete;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}
