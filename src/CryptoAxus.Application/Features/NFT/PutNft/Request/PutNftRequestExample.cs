namespace CryptoAxus.Application.Features.NFT.PutNft.Request;

public class PutNftRequestExample : IExamplesProvider<PutNftRequest>
{
    public PutNftRequest GetExamples()
    {
        UpdateNftDto dto = new UpdateNftDto("Contract Address",
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
                                            ObjectId.GenerateNewId().ToString());

        return new PutNftRequest(null, dto);
    }
}