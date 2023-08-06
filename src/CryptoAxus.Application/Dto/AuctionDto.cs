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

    public AuctionDto() : base()
    {
    }

    public AuctionDto(ObjectId id,
                      string? nftId = null,
                      string? nftCopyId = null,
                      int? quantity = null,
                      decimal? minimumBid = null,
                      bool? softDelete = null,
                      DateTime? startingDateTime = null,
                      DateTime? endingDateTime = null,
                      string? createdBy = null,
                      DateTime? lastModifiedDate = null,
                      string? lastModifiedBy = null,
                      bool isDeleted = false)
                      : base(id,
                             createdBy,
                             lastModifiedDate,
                             lastModifiedBy)
    {
        NftId = nftId;
        NftCopyId = nftCopyId;
        Quantity = quantity;
        MinimumBid = minimumBid;
        SoftDelete = softDelete;
        StartingDateTime = startingDateTime;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}
