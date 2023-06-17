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

    public AllEventDto() : base()
    {
    }

    public AllEventDto(ObjectId id,
                       string? nftId = null,
                       int? marketTokenId = null,
                       string? mintingContract = null,
                       string? walletAddress = null,
                       int? tokenId = null,
                       int? quantity = null,
                       string? seller = null,
                       string? eventName = null,
                       bool isSold = false,
                       bool accepted = false,
                       bool rejected = false,
                       ObjectId? createdBy = null,
                       string? buyer = null,
                       DateTime? listingEndAt = null,
                       decimal? price = null,
                       bool isDeleted = false,
                       decimal? offerAmount = null,
                       DateTime? listedAt = null,
                       DateTime? canceledAt = null,
                       DateTime? soldAt = null,
                       DateTime? lastModifiedDate = null,
                       ObjectId? lastModifiedBy = null)
                       : base(id,
                              createdBy,
                              lastModifiedDate,
                              lastModifiedBy,
                              isDeleted)
    {
        Id = id;
        NftId = nftId;
        MarketTokenId = marketTokenId;
        MintingContract = mintingContract;
        WalletAddress = walletAddress;
        TokenId = tokenId;
        Quantity = quantity;
        Seller = seller;
        EventName = eventName;
        Buyer = buyer;
        Price = price;
        OfferAmount = offerAmount;
        ListedAt = listedAt;
        ListingEndAt = listingEndAt;
        CanceledAt = canceledAt;
        SoldAt = soldAt;
        IsSold = isSold;
        Accepted = accepted;
        Rejected = rejected;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}
