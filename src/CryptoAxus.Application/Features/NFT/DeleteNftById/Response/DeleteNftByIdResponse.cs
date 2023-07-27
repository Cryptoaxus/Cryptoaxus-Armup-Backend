namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class DeleteNftByIdResponse : BaseResponse<object>
{
    public DeleteNftByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }
}