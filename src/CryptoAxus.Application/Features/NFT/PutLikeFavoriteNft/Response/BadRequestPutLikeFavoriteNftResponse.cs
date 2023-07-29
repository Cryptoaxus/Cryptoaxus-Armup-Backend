namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;

public class BadRequestPutLikeFavoriteNftResponse : PutLikeFavoriteNftResponse
{
    public BadRequestPutLikeFavoriteNftResponse(string? message) : base(HttpStatusCode.BadRequest, message) { }
}