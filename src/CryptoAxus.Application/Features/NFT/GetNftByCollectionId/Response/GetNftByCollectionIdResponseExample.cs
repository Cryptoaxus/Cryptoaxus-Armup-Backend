namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Response;

public class GetNftByCollectionIdResponseExample : IExamplesProvider<GetNftByCollectionIdResponse>
{
    public GetNftByCollectionIdResponse GetExamples()
    {
        return new GetNftByCollectionIdResponse(HttpStatusCode.OK,
                                                "Records found successfully.",
                                                new List<NftDto>
                                                {
                                                    new NftDto(ObjectId.GenerateNewId(),
                                                               "contractAddress",
                                                               "hash",
                                                               "https://www.google.com",
                                                               "signature",
                                                               45268,
                                                               10,
                                                               "Example Nft",
                                                               "https://www.google.com",
                                                               "Example description",
                                                               "Example Collection",
                                                               ObjectId.GenerateNewId().ToString(),
                                                               "Ethereum",
                                                               450,
                                                               new List<string>
                                                                       { ObjectId.GenerateNewId().ToString() },
                                                               new List<string>
                                                                       { ObjectId.GenerateNewId().ToString() },
                                                               ObjectId.GenerateNewId().ToString()),
                                                    new NftDto(ObjectId.GenerateNewId(),
                                                               "contractAddress",
                                                               "hash",
                                                               "https://www.google.com",
                                                               "signature",
                                                               45268,
                                                               10,
                                                               "Example Nft",
                                                               "https://www.google.com",
                                                               "Example description",
                                                               "Example Collection",
                                                               ObjectId.GenerateNewId().ToString(),
                                                               "Ethereum",
                                                               450,
                                                               new List<string>
                                                                       { ObjectId.GenerateNewId().ToString() },
                                                               new List<string>
                                                                       { ObjectId.GenerateNewId().ToString() },
                                                               ObjectId.GenerateNewId().ToString())
                                                });
    }
}