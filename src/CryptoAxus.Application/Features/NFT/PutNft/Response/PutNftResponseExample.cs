namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class PutNftResponseExample : IExamplesProvider<PutNftResponse>
{
    public PutNftResponse GetExamples()
    {
        return new PutNftResponse(HttpStatusCode.NoContent,
                                  "Nft updated successfully.",
                                  new NftDto(ObjectId.GenerateNewId().ToObjectId(),
                                             "Contract Address",
                                             "Hash",
                                             "https://www.google.com/",
                                             "Signature",
                                             450,
                                             10,
                                             "Example Nft",
                                             "https://www.google.com/",
                                             "Example Description",
                                             "Example Collection",
                                             ObjectId.GenerateNewId(),
                                             "Ethereum",
                                             100,
                                             ObjectId.GenerateNewId(),
                                             DateTime.UtcNow,
                                             ObjectId.GenerateNewId()));
    }
}