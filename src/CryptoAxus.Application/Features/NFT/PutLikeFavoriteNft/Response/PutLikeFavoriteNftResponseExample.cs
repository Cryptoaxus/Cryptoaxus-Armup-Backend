namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;

public class PutLikeFavoriteNftResponseExample : IExamplesProvider<PutLikeFavoriteNftResponse>
{
    public PutLikeFavoriteNftResponse GetExamples()
    {
        return new PutLikeFavoriteNftResponse(HttpStatusCode.OK, "Nft liked successfully.");
    }
}