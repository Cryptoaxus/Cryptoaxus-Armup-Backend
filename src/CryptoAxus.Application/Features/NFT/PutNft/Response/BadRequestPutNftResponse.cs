namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class BadRequestPutNftResponse : PutNftResponse
{
    public BadRequestPutNftResponse(string? message) : base(HttpStatusCode.BadRequest, message) { }
}