namespace CryptoAxus.Application.Features.Nft.GetAllNft;

public class GetAllNftTestData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private readonly Mock<ICacheService> _mockCacheService;
    private readonly List<NftDocument> _documents;

    public GetAllNftTestData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        _mockCacheService = new Mock<ICacheService>();
        _documents = new List<NftDocument>
        {
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId()),
            new NftDocument(ObjectId.GenerateNewId(), "contract-Address", "hash", "https://www.google.com/",
                            "Mock Signature", 12345, 5, "Mock Nft", "https://www.google.com/", "Mock Description",
                            "Mock Collection", ObjectId.GenerateNewId(), "Ethereum", 450,
                            ObjectId.GenerateNewId())
        };
    }

    public GetAllNftTestData SetupMockCacheService()
    {
        _mockCacheService.Setup(x => x.GetAsync<string?>(It.IsAny<string>()))
                         .ReturnsAsync("Cached value");

        return this;
    }

    public GetAllNftTestData SetupMockCacheServiceExists()
    {
        _mockCacheService.Setup(x => x.GetAsync<GetAllNftResponse>(It.IsAny<string>()))
                         .ReturnsAsync(new GetAllNftResponse(HttpStatusCode.OK,
                                                             "Records found successfully.",
                                                             _documents.Adapt<List<NftDto>>(),
                                                             new PaginationData(100, 1, 25)));

        return this;
    }

    public GetAllNftTestData SetupMockRepository(int pageNumber, int pageSize)
    {
        _documents.AddRange(_documents);

        _mockRepository.SetupSequence(x => x.CountAsync(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                                      It.IsAny<CancellationToken>()))
                       .ReturnsAsync(100)
                       .ReturnsAsync(50)
                       .ReturnsAsync(485);

        _mockRepository.SetupSequence(x => x.FilterBy(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                                    It.IsAny<int?>(),
                                                                                    It.IsAny<int?>(),
                                                                                    It.IsAny<CancellationToken>()))
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList())
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList())
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList());

        return this;
    }

    public GetAllNftTestData SetupMockRepositoryNotFound()
    {
        _mockRepository.SetupSequence(x => x.CountAsync(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                                        It.IsAny<CancellationToken>()))
                       .ReturnsAsync(0)
                       .ReturnsAsync(0);

        _mockRepository.SetupSequence(x => x.FilterBy(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                                                                       It.IsAny<int?>(),
                                                                                       It.IsAny<int?>(),
                                                                                       It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new List<NftDocument>())
                       .ReturnsAsync(new List<NftDocument>());

        return this;
    }

    protected GetAllNftRequest CreateRequest(int pageNumber, int pageSize)
    {
        return new GetAllNftRequest(new PaginationParameters(pageNumber, pageSize, string.Empty));
    }

    public GetAllNftHandler Build()
    {
        return new GetAllNftHandler(_mockRepository.Object, _mockCacheService.Object);
    }
}