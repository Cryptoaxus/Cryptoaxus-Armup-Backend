namespace CryptoAxus.Application.Features.NftCollection.PutNftCollectionById.Response;

public class PutNftCollectionByIdResponse : BaseResponse<NftCollectionsDto>
{
    public PutNftCollectionByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public PutNftCollectionByIdResponse(NftCollectionsDto result) : this(HttpStatusCode.NoContent, "Record updated successfully.") =>
            Result = result;
}