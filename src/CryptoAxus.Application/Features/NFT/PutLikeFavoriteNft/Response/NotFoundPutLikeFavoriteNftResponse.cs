namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;

public class NotFoundPutLikeFavoriteNftResponse : PutLikeFavoriteNftResponse
{
    public NotFoundPutLikeFavoriteNftResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}