namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Response;

public class BadRequestGetNftCollectionByIdResponse : GetNftCollectionByIdResponse
{
    public BadRequestGetNftCollectionByIdResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}