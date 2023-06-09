namespace CryptoAxus.Application.Dto;

public class AuctionDto : BaseDto
{
    public string? NftId { get; set; }

    public string? NftCopyId { get; set; }

    public int? Quantity { get; set; }

    public decimal? MinimumBid { get; set; }

    public bool? SoftDelete { get; set; }

    public DateTime? StartingDateTime { get; set; }

    public DateTime? EndingDateTime { get; set; }

    public AuctionDto()
    {
    }
}
