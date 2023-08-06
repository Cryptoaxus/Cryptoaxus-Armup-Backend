namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Response;

public class GetNftCollectionByIdResponse : BaseResponse<NftCollectionsDto>
{
    public GetNftCollectionByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetNftCollectionByIdResponse(NftCollectionsDto result) : this(HttpStatusCode.OK, "Record found successfully.") => Result = result;
}