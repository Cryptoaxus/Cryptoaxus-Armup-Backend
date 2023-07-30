namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Request;

public class GetLikeFavoriteNftByArtistRequest : IRequest<GetLikeFavoriteNftByArtistResponse>
{
    internal string UserId { get; set; }

    public GetLikeFavoriteNftByArtistRequest(string userId) => UserId = userId;
}