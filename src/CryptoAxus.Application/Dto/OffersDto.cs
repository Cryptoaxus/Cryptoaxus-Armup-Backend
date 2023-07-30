namespace CryptoAxus.Application.Dto;

public class OffersDto : BaseDto
{
    public string? NftId { get; set; }

    public decimal? OfferPrice { get; set; }

    public int? OfferFrom { get; set; }

    public int? OfferTo { get; set; }

    public int? Quantity { get; set; }

    public int? OfferedQuantity { get; set; }

    public DateTime? OfferExpireAt { get; set; }

    public OffersDto() { }

    public OffersDto(ObjectId id,
                     string? nftId = null,
                     decimal? offerPrice = null,
                     int? offerFrom = null,
                     int? offerTo = null,
                     int? quantity = null,
                     int? offeredQuantity = null,
                     DateTime? offerExpireAt = null,
                     string? createdBy = null,
                     DateTime? lastModifiedDate = null,
                     string? lastModifiedBy = null,
                     bool isDeleted = false)
                     : base(id,
                            createdBy,
                            lastModifiedDate,
                            lastModifiedBy,
                            isDeleted)
    {
        NftId = nftId;
        OfferPrice = offerPrice;
        OfferFrom = offerFrom;
        OfferTo = offerTo;
        Quantity = quantity;
        OfferedQuantity = offeredQuantity;
        OfferExpireAt = offerExpireAt;
    }
}