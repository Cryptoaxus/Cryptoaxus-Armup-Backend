namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class BadRequestDeleteNftByIdResponse : DeleteNftByIdResponse
{
    public BadRequestDeleteNftByIdResponse(string? message) : base(HttpStatusCode.BadRequest, message) { }
}