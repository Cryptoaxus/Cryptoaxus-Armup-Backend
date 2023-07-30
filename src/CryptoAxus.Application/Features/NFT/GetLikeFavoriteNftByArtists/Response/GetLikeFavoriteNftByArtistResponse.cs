namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;

public class GetLikeFavoriteNftByArtistResponse : BaseResponse<LikeFavoriteNftDto>
{
    public GetLikeFavoriteNftByArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }

    public GetLikeFavoriteNftByArtistResponse(HttpStatusCode statusCode, string? message, LikeFavoriteNftDto result)
                                       : this(statusCode, message) => Result = result;
}