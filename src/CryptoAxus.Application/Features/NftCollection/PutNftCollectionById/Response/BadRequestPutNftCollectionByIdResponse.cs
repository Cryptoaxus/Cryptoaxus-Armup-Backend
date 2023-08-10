namespace CryptoAxus.Application.Features.NftCollection.PutNftCollectionById.Response;

public class BadRequestPutNftCollectionByIdResponse : PutNftCollectionByIdResponse
{
    public BadRequestPutNftCollectionByIdResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}