namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Response;

public class BadRequestGetNftCollectionsByCategoryResponse : GetNftCollectionsByCategoryResponse
{
    public BadRequestGetNftCollectionsByCategoryResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}