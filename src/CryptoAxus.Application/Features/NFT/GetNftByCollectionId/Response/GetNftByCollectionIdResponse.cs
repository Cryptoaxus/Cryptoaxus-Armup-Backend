namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Response;

public class GetNftByCollectionIdResponse : BaseResponse<IEnumerable<NftDto>>
{
    public GetNftByCollectionIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }

    public GetNftByCollectionIdResponse(HttpStatusCode statusCode, string? message, IEnumerable<NftDto> result)
                                 : this(statusCode, message) => Result = result;
}