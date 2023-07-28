namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class NotFoundPutNftResponse : PutNftResponse
{
    public NotFoundPutNftResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}