namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Response;

public class NotFoundPutLikeFavoriteNftResponseExample : IExamplesProvider<NotFoundPutLikeFavoriteNftResponse>
{
    public NotFoundPutLikeFavoriteNftResponse GetExamples()
    {
        return new NotFoundPutLikeFavoriteNftResponse("No nft exist against id: 507f191e810c19729de860ea.");
    }
}