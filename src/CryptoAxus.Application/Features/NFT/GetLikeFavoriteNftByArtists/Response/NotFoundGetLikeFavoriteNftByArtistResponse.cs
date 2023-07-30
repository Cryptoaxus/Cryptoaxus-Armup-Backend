namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;

public class NotFoundGetLikeFavoriteNftByArtistResponse : GetLikeFavoriteNftByArtistResponse
{
    public NotFoundGetLikeFavoriteNftByArtistResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}