namespace CryptoAxus.Application.Dto;

public class OffersDto : BaseDto
{
    public string? NftId { get; set; }

    public decimal? OfferPrice { get; set; }

    public int? OfferFrom { get; set; }

    public string? OfferTo { get; set; }

    public int? Quantity { get; set; }

    public DateTime? OfferExpireAt { get; set; }

    public int? OfferedQuantity { get; set; }

    public OffersDto() : base()
    {
    }

    public OffersDto(ObjectId id,
                     string? nftId = null,
                     decimal? offerPrice = null,
                     int? offerFrom = null,
                     string? offerTo = null,
                     DateTime? offerExpireAt = null,
                     int? quantity = null,
                     int? offeredQuantity = null,
                     ObjectId? createdBy = null,
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
        NftId = nftId;
        OfferPrice = offerPrice;
        OfferFrom = offerFrom;
        OfferTo = offerTo;
        Quantity = quantity;
        OfferExpireAt = offerExpireAt;
        OfferedQuantity = offeredQuantity;
        CreatedBy = createdBy;
    }
}
