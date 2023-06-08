namespace CryptoAxus.Domain.Collections;

[BsonCollection("Offers")]
public class OffersDocument : BaseDocument
{
    [BsonElement(elementName: "nftId", Order = 2)]
    public string NftId { get; set; }

    [BsonElement(elementName: "offerPrice", Order = 3)]
    public decimal OfferPrice { get; set; }

    [BsonElement(elementName: "offerFrom", Order = 4)]
    public int OfferFrom { get; set; }

    [BsonElement(elementName: "offerTo", Order = 5)]
    public string OfferTo { get; set; }

    [BsonElement(elementName: "quantity", Order = 6)]
    public int? Quantity  { get; set; }

    [BsonElement(elementName: "offerExpireAt", Order = 7)]
    public DateTime OfferExpireAt { get; set; }
    
    [BsonElement(elementName: "offeredQuantity", Order = 9)]
    public int OfferedQuantity { get; set; }

    public OffersDocument() : base()
    {
    }

    public OffersDocument(ObjectId id, string nftId,
                          decimal offerPrice,
                          int  offerFrom,
                          string offerTo,
                          DateTime offerExpireAt,
                          int offeredQuantity,
                          ObjectId createdBy,
                          DateTime? lastModifiedDate = null,
                          ObjectId? lastModifiedBy = null,
                          string? signature = null,
                          int? quantity = null,
                          bool isDeleted = false)
                          : base(id,
                                 createdBy,
                                 lastModifiedDate,
                                 lastModifiedBy,
                                 isDeleted)
    {
        Id = id;
        NftId = nftId;
        OfferPrice = offerPrice;
        OfferFrom = offerFrom;
        OfferTo = offerTo;
        Quantity = quantity;
        OfferExpireAt = offerExpireAt;
        OfferedQuantity = offeredQuantity;
        CreatedBy= createdBy;
    }
}
