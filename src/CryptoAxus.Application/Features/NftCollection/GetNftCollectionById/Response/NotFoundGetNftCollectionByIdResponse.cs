namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Response;

public class NotFoundGetNftCollectionByIdResponse : GetNftCollectionByIdResponse
{
    public NotFoundGetNftCollectionByIdResponse(string? message) : base(HttpStatusCode.NotFound, message)
    {
    }
}