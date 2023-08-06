namespace CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Response;

public class BadRequestDeleteNftCollectionByIdResponse : DeleteNftCollectionByIdResponse
{
    public BadRequestDeleteNftCollectionByIdResponse(string? id) : base(HttpStatusCode.BadRequest, $"Unable to delete record with id: {id}.")
    {
    }
}