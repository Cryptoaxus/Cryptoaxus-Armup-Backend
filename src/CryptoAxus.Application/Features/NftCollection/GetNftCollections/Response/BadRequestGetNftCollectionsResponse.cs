namespace CryptoAxus.Application.Features.NftCollection.GetNftCollections.Response;

public class BadRequestGetNftCollectionsResponse : GetNftCollectionsResponse
{
    public BadRequestGetNftCollectionsResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}