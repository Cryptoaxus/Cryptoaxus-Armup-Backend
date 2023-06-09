namespace CryptoAxus.Application.Dto;

public class BiddingDto : BaseDto
{
    public string? NftId { get; set; }

    public decimal? BiddingPrice { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? FromWalletAddress { get; set; }

    public string? BidderUserName { get; set; }

    public bool? HighestBid { get; set; }

    public BiddingDto()
    {
    }
}