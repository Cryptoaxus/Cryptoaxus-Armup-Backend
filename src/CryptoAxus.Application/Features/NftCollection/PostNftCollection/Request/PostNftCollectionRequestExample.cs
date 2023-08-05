namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Request;

public class PostNftCollectionRequestExample : IExamplesProvider<PostNftCollectionRequest>
{
    public PostNftCollectionRequest GetExamples()
    {
        return new PostNftCollectionRequest(new CreateNftCollectionsDto("logo-hash",
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