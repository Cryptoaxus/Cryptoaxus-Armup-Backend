namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class NotFoundDeleteNftByIdResponse : DeleteNftByIdResponse
{
    public NotFoundDeleteNftByIdResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}