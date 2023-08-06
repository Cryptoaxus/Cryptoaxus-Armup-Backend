namespace CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Response;

public class NotFoundDeleteNftCollectionByIdResponse : DeleteNftCollectionByIdResponse
{
    public NotFoundDeleteNftCollectionByIdResponse(string? id) : base(HttpStatusCode.NotFound, $"No record exist against id: {id}.")
    {
    }
}