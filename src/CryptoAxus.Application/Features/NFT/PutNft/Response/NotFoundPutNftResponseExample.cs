namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class NotFoundPutNftResponseExample : IExamplesProvider<NotFoundPutNftResponse>
{
    public NotFoundPutNftResponse GetExamples()
    {
        return new NotFoundPutNftResponse("No nft found against id: 507f191e810c19729de860ea.");
    }
}