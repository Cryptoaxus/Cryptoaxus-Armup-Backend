namespace CryptoAxus.Application.Dto;

public class FixedPricedDto : BaseDto
{
    public string? NftCopyId { get; set; }

    public int? Quantity { get; set; }

    public decimal? PricePerItem { get; set; }

    public DateTime? FixedEndingDateTime { get; set; }

    public bool? SoftDelete { get; set; }

    public FixedPricedDto() : base()
    {
    }

    public FixedPricedDto(ObjectId id,
                          string? nftCopyId = null,
                          int? quantity = null,
                          decimal? pricePerItem = null,
                          DateTime? fixedEndingDateTime = null,
                          bool? softDelete = null,
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
        NftCopyId = nftCopyId;
        Quantity = quantity;
        PricePerItem = pricePerItem;
        FixedEndingDateTime = fixedEndingDateTime;
        SoftDelete = softDelete;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}
