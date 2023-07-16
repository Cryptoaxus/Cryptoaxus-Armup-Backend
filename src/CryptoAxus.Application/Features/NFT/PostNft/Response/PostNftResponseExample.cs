namespace CryptoAxus.Application.Features.NFT.PostNft.Response;

public class PostNftResponseExample : IExamplesProvider<PostNftResponse>
{
    public PostNftResponse GetExamples()
    {
        return new PostNftResponse(new NftDto("64af165b60851637d8063440".ToObjectId(),
                                              "0x50251526b476CA288AD6a754aaC7A1455130f4d6",
                                              "QmZfnCHWuv9pxg13bBJgZ99xZ8ravRk1RNVtRNHqWWcnF8",
                                              "https://cryptoaxus.mypinata.cloud/ipfs/",
                                              "0x29f8329e9e6d0e221ecb4bb7525968688c8f47311929ec4",
                                              344606,
                                              10,
                                              "Ford Mustang GT artwork",
                                              "https://www.google.com/",
                                              "State of the art muscle sports car that can cruise the streets",
                                              "Exotic cars collection",
                                              ObjectId.GenerateNewId(),
                                              "Ethereum",
                                              450,
                                              ObjectId.GenerateNewId()));
    }
}