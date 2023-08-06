namespace CryptoAxus.Application.Features.NftCollection.GetNftCollections.Response;

public class NotFoundGetNftCollectionsResponse : GetNftCollectionsResponse
{
    public NotFoundGetNftCollectionsResponse() : base(HttpStatusCode.NotFound, "No record exist in system.")
    {
    }
}