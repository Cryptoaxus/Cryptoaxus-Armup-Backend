namespace CryptoAxus.Application.Features.Nft.GetNftByCollectionId;

public class GetNftByCollectionIdTestsData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private List<NftDocument> _mockDocument;

    public GetNftByCollectionIdTestsData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        _mockDocument = new List<NftDocument>();
        NftDocument document = new NftDocument(ObjectId.GenerateNewId(), "contractAddress", "hash",
                                               "https://www.google.com", "signature", 425692, 10,
                                               "Mock Nft", "https://www.google.com", "Mock Description",
                                               "Mock Collection", ObjectId.GenerateNewId().ToString(), "Ethereum",
                                               450, ObjectId.GenerateNewId().ToString());
        for (int i = 0; i < 10; i++)
        {
            _mockDocument.Add(document);
        }
    }

    public GetNftByCollectionIdTestsData SetupMockRepository(bool exists)
    {
        if (!exists)
            _mockDocument = new List<NftDocument>();

        _mockRepository
               .Setup(x => x.FilterByAsync(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                           null, null, It.IsAny<CancellationToken>()))
               .ReturnsAsync(_mockDocument);

        return this;
    }

    public GetNftByCollectionIdRequest CreateRequest(string collectionId)
    {
        return new GetNftByCollectionIdRequest(collectionId);
    }

    public GetNftByCollectionIdHandler Build()
    {
        return new GetNftByCollectionIdHandler(_mockRepository.Object);
    }
}