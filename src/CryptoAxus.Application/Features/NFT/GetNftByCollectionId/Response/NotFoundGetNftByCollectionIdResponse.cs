namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Response;

public class NotFoundGetNftByCollectionIdResponse : GetNftByCollectionIdResponse
{
    public NotFoundGetNftByCollectionIdResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}