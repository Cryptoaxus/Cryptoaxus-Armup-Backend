namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;

public class GetLikeFavoriteNftByArtistResponseExample : IExamplesProvider<GetLikeFavoriteNftByArtistResponse>
{
    public GetLikeFavoriteNftByArtistResponse GetExamples()
    {
        return new GetLikeFavoriteNftByArtistResponse(HttpStatusCode.OK,
                                                      "Records found successfully.",
                                                      new LikeFavoriteNftDto(likedNft: new List<NftDto>
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
                                                                           ObjectId.GenerateNewId())
                                                            },
                                                            favoriteNft: new List<NftDto>
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
                                                                           ObjectId.GenerateNewId())
                                                            }));
    }
}