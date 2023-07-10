namespace CryptoAxus.Application.Dto;

public class OffersDtoWithLinks : OffersDto
{
    public IReadOnlyList<Links>? Links { get; set; }

    public OffersDtoWithLinks()
    {
    }

    public OffersDtoWithLinks(ObjectId id,
                              string? nftId = null,
                              decimal? offerPrice = null,
                              int? offerFrom = null,
                              int? offerTo = null,
                              int? quantity = null,
                              int? offeredQuantity = null,
                              DateTime? offerExpireAt = null,
                              IReadOnlyList<Links>? links = null,
                              ObjectId? createdBy = null,
                              DateTime? lastModifiedDate = null,
                              ObjectId? lastModifiedBy = null,
                              bool isDeleted = false) :
                              base(id,
                                   nftId,
                                   offerPrice,
                                   offerFrom,
                                   offerTo,
                                   quantity,
                                   offeredQuantity,
                                   offerExpireAt,
                                   createdBy,
                                   lastModifiedDate,
                                   lastModifiedBy,
                                   isDeleted)
    {
        Links = links;
    }
}