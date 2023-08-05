namespace CryptoAxus.Application.Features.Nft.PostNftCollection;

public class PostNftCollectionTestsData
{
    private readonly Mock<IRepository<NftCollectionsDocument>> _mockRepository;

    public PostNftCollectionTestsData()
    {
        _mockRepository = new Mock<IRepository<NftCollectionsDocument>>();
    }

    public PostNftCollectionTestsData SetupMockRepositoryExist(bool exist)
    {
        _mockRepository.Setup(x => x.Exists(It.IsAny<Expression<Func<NftCollectionsDocument, bool>>>(), default))
                       .ReturnsAsync(exist);

        return this;
    }

    public PostNftCollectionTestsData SetupMockRepositoryInsert()
    {
        _mockRepository.Setup(x => x.InsertOneAsync(It.IsAny<NftCollectionsDocument>()))
                       .Returns(Task.CompletedTask);

        return this;
    }

    public PostNftCollectionRequest CreateRequest()
    {
        return new PostNftCollectionRequest(new CreateNftCollectionsDto("logoHash",
                                                                        "imageHash",
                                                                        "bannerHash",
                                                                        "collectionName",
                                                                        "walletAddress",
                                                                        "https://www.google.com",
                                                                        "description",
                                                                        "category",
                                                                        "Ethereum",
                                                                        false,
                                                                        ObjectId.GenerateNewId().ToString()));
    }

    public PostNftCollectionHandler Build()
    {
        return new PostNftCollectionHandler(_mockRepository.Object);
    }
}