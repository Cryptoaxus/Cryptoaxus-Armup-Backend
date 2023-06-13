namespace CryptoAxus.Application.Dto;

public class BiddingDto : BaseDto
{
    public string? NftId { get; set; }

    public decimal? BiddingPrice { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? FromWalletAddress { get; set; }

    public string? BidderUserName { get; set; }

    public bool? HighestBid { get; set; }

    public BiddingDto() : base()
    {
    }
    public BiddingDto(ObjectId id,
                      string? nftId = null,
                      decimal? biddingPrice = null,
                      string? minimumBid = null,
                      string? artistWalletAddress = null,
                      string? fromWalletAddress = null,
                      bool? highestBid = null,
                      ObjectId? createdBy = null,
                      DateTime? lastModifiedDate = null,
                      ObjectId? lastModifiedBy = null,
                      string? bidderUserName = null,
                      bool isDeleted = false)
                      : base(id,
                             createdBy,
                             lastModifiedDate,
                             lastModifiedBy,
                             isDeleted)
    {
        Id = id;
        NftId = nftId;
        BiddingPrice = biddingPrice;
        ArtistWalletAddress = artistWalletAddress;
        FromWalletAddress = fromWalletAddress;
        BidderUserName = bidderUserName;
        HighestBid = highestBid;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}