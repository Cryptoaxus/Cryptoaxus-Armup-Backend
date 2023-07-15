namespace CryptoAxus.Application.Dto;

public class FavoriteNftsDto : BaseDto
{
    public string? NftId { get; set; }

    public string? ArtistWalletAddress { get; set; }

    public string? CollectionId { get; set; }

    public FavoriteNftsDto() : base()
    {
    }
    public FavoriteNftsDto(ObjectId id,
                           string? nftId = null,
                           string? artistWalletAddress = null,
                           string? collectionId = null,
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
        NftId = nftId;
        ArtistWalletAddress = artistWalletAddress;
        CollectionId = collectionId;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}
