namespace CryptoAxus.Application.Features.Nft.PostNft;

public class PostNftTestData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;

    protected PostNftTestData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
    }

    public PostNftTestData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.Exists(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                         It.IsAny<CancellationToken>()))
                       .ReturnsAsync(false);

        _mockRepository.Setup(x => x.InsertOneAsync(It.IsAny<NftDocument>()))
                       .Returns(Task.CompletedTask);

        return this;
    }

    public PostNftTestData SetupMockNftExists()
    {
        _mockRepository.Setup(x => x.Exists(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                         It.IsAny<CancellationToken>()))
                       .ReturnsAsync(true);

        return this;
    }

    public PostNftRequest CreateRequest()
    {
        return new PostNftRequest(new CreateNftDto("contractAddress",
                                                   "hash",
                                                   "https://www.google.com/",
                                                   "signature",
                                                   2482,
                                                   5,
                                                   "Test Nft",
                                                   "https://www.google.com/",
                                                   "Test Description",
                                                   "Test Collection",
                                                   "64b0509a33c4d3fab00cf5a1",
                                                   "Ethereum",
                                                   240,
                                                   "64b0509a33c4d3fab00cf5a1"));
    }

    public PostNftHandler Build()
    {
        return new PostNftHandler(_mockRepository.Object);
    }
}