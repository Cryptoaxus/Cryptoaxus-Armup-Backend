namespace CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Response;

public class DeleteNftCollectionByIdResponse : BaseResponse<object>
{
    public DeleteNftCollectionByIdResponse() : base(HttpStatusCode.NoContent, "Record deleted successfully.")
    {
    }

    public DeleteNftCollectionByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}