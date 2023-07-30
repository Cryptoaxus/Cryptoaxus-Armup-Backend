namespace CryptoAxus.Application.Features.Nft.GetNftById;

public class GetNftByIdTestData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private NftDocument? _nftDocument;

    public GetNftByIdTestData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        _nftDocument = new NftDocument(ObjectId.GenerateNewId(),
                                       "contractAddress",
                                       "hash",
                                       "https://www.google.com/",
                                       "signature",
                                       45020,
                                       10,
                                       "Test Nft",
                                       "https://www.google.com/",
                                       "Test Description",
                                       "Test Collection",
                                       ObjectId.GenerateNewId().ToString(),
                                       "Ethereum",
                                       450,
                                       ObjectId.GenerateNewId());
    }

    public GetNftByIdTestData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(_nftDocument);

        return this;
    }

    public GetNftByIdTestData SetupMockRepositoryReturnNull()
    {
        _nftDocument = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(_nftDocument);

        return this;
    }

    public GetNftByIdRequest CreateRequest()
    {
        return new GetNftByIdRequest(ObjectId.GenerateNewId().ToString());
    }

    public GetNftByIdHandler Build()
    {
        return new GetNftByIdHandler(_mockRepository.Object);
    }
}