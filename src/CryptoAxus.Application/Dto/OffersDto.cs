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

    public OffersDto()
    {
    }
}