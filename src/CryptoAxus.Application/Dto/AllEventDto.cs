namespace CryptoAxus.Application.Dto;

public class AllEventDto : BaseDto
{
    public string? NftId { get; set; }

    public int? MarketTokenId { get; set; }

    public string? MintingContract { get; set; }

    public string? WalletAddress { get; set; }

    public int? TokenId { get; set; }

    public int? Quantity { get; set; }

    public string? Seller { get; set; }

    public string? EventName { get; set; }

    public string? Buyer { get; set; }
    
    public decimal? Price { get; set; }

    public decimal? OfferAmount { get; set; }

    public DateTime? ListedAt { get; set; }

    public DateTime? ListingEndAt { get; set; }

    public DateTime? CanceledAt { get; set; }

    public DateTime? SoldAt { get; set; }

    public bool? IsSold { get; set; }

    public bool? Accepted { get; set; }

    public bool? Rejected { get; set; }

    public AllEventDto()
    {
    }
}
