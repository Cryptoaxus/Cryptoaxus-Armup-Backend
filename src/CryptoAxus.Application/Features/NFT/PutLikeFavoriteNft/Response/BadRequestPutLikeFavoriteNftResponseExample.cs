namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;

public class BadRequestPutLikeFavoriteNftResponseExample : IExamplesProvider<BadRequestPutLikeFavoriteNftResponse>
{
    public BadRequestPutLikeFavoriteNftResponse GetExamples()
    {
        return new BadRequestPutLikeFavoriteNftResponse("Unable to patch nft.");
    }
}