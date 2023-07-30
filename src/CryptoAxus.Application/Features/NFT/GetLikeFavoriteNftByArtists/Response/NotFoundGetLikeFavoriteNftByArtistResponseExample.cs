namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;

public class NotFoundGetLikeFavoriteNftByArtistResponseExample : IExamplesProvider<NotFoundGetLikeFavoriteNftByArtistResponse>
{
    public NotFoundGetLikeFavoriteNftByArtistResponse GetExamples()
    {
        return new NotFoundGetLikeFavoriteNftByArtistResponse($"No records found against artist id: {ObjectId.GenerateNewId()}");
    }
}