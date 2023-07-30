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
                                             ObjectId.GenerateNewId().ToString(),
                                             "Ethereum",
                                             100,
                                             null,
                                             null,
                                             ObjectId.GenerateNewId().ToString(),
                                             DateTime.UtcNow,
                                             ObjectId.GenerateNewId().ToString()));
    }
}