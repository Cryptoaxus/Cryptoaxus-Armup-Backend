namespace CryptoAxus.Application.Features.NFT.GetNftById.Response;

public class GetNftByIdResponse : BaseResponse<NftDto>
{
    public GetNftByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetNftByIdResponse(HttpStatusCode statusCode, string? message, NftDto? result) : base(statusCode, message, result)
    {
    }
}