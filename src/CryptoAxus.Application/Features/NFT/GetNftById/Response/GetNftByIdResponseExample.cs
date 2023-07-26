namespace CryptoAxus.Application.Features.NFT.GetNftById.Response;

public class GetNftByIdResponseExample : IExamplesProvider<GetNftByIdResponse>
{
    public GetNftByIdResponse GetExamples()
    {
        return new GetNftByIdResponse(HttpStatusCode.OK,
                                      "Record found successfully.",
                                      new NftDto(ObjectId.GenerateNewId(),
                                                 "0x45a5ce35g5e5c14542ec",
                                                 "hash-value",
                                                 "https://www.google.com/",
                                                 "signature",
                                                 4258,
                                                 5,
                                                 "Example Nft",
                                                 "https://www.google.com/",
                                                 "Example description",
                                                 "Example collection",
                                                 ObjectId.GenerateNewId(),
                                                 "Ethereum",
                                                 450,
                                                 ObjectId.GenerateNewId()));
    }
}