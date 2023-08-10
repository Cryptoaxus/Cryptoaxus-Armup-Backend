namespace CryptoAxus.Application.Features.NftCollection.PutNftCollectionById.Response;

public class NotFoundPutNftCollectionByIdResponse : PutNftCollectionByIdResponse
{
    public NotFoundPutNftCollectionByIdResponse(string? id) : base(HttpStatusCode.NotFound, $"No record found against id: {id}.")
    {
    }
}