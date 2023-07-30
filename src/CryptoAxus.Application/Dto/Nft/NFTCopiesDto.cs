namespace CryptoAxus.Application.Dto.Nft;

public class NFTCopiesDto : BaseDto
{
    public string? NftId { get; set; }

    public string? Owner { get; set; }

    public string? OwnerName { get; set; }

    public int? Quantity { get; set; }

    public bool? IsCreator { get; set; }

    public int? MarketTokenId { get; set; }

    public NFTCopiesDto() : base()
    {
    }

    public NFTCopiesDto(ObjectId id,
                        string? nftId = null,
                        string? owner = null,
                        string? ownerName = null,
                        int? quantity = null,
                        bool? isCreator = null,
                        int? marketTokenId = null,
                        string? bidderUserName = null,
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
        Owner = owner;
        Quantity = quantity;
        IsCreator = isCreator;
        MarketTokenId = marketTokenId;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}



