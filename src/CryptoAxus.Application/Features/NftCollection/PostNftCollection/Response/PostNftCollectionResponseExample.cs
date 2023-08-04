namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;

public class PostNftCollectionResponseExample : IExamplesProvider<PostNftCollectionResponse>
{
    public PostNftCollectionResponse GetExamples()
    {
        return new PostNftCollectionResponse(new NftCollectionsDto(ObjectId.GenerateNewId(),
                                                                   "logo-hash",
                                                                   "image-hash",
                                                                   "banner-hash",
                                                                   "collection-name",
                                                                   "wallet-address",
                                                                   "https://www.google.com",
                                                                   "description",
                                                                   "category",
                                                                   "Ethereum",
                                                                   false,
                                                                   ObjectId.GenerateNewId().ToString()));
    }
}