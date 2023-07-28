namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class BadRequestPutNftResponseExample : IExamplesProvider<BadRequestPutNftResponse>
{
    public BadRequestPutNftResponse GetExamples()
    {
        return new BadRequestPutNftResponse("Unable to update nft");
    }
}