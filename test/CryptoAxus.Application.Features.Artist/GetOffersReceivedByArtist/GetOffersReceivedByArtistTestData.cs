namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist;

public class GetOffersReceivedByArtistTestData
{
    private readonly Mock<IRepository<OffersDocument>> _mockRepository;
    private readonly Mock<ICacheService> _mockCacheService;
    private readonly List<OffersDocument> _documents;
    protected GetOffersReceivedByArtistTestData()
    {
        _mockRepository = new Mock<IRepository<OffersDocument>>();
        _mockCacheService = new Mock<ICacheService>();
        _documents = new List<OffersDocument> {
             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                247,
                                547,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                248,
                                548,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                249,
                                549,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                250,
                                550,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                251,
                                551,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                252,
                                552,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                252,
                                552,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                253,
                                553,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                254,
                                554,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString()),

             new OffersDocument(ObjectId.GenerateNewId(),
                                "nftId",
                                Convert.ToDecimal(50.45),
                                255,
                                555,
                                10,
                                DateTime.UtcNow.AddHours(6),
                                5,
                                ObjectId.GenerateNewId().ToString())
        };
    }

    public GetOffersReceivedByArtistTestData SetupMockCacheService()
    {
        _mockCacheService.Setup(x => x.GetAsync<string?>(It.IsAny<string>()))
                         .ReturnsAsync("Cached value");

        _mockCacheService.Setup(x => x.SetAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        return this;
    }


    public GetOffersReceivedByArtistTestData SetupMockCacheServiceExists()
    {
        _mockCacheService.Setup(x => x.GetAsync<GetOffersReceivedByArtistResponse>(It.IsAny<string>()))
                         .ReturnsAsync(new GetOffersReceivedByArtistResponse(HttpStatusCode.OK,
                                                                             "Records found successfully.",
                                                                             _documents.Adapt<List<OffersDtoWithLinks>>(),
                                                                             new PaginationData(100, 1, 25)));
        return this;
    }

    public GetOffersReceivedByArtistTestData SetupMockRepository(int pageNumber, int pageSize)
    {
        _documents.AddRange(_documents);

        _mockRepository.SetupSequence(x => x.CountAsync(It.IsAny<Expression<Func<OffersDocument, bool>>>(),
                                                        It.IsAny<CancellationToken>()))
                       .ReturnsAsync(100)
                       .ReturnsAsync(50)
                       .ReturnsAsync(485);

        _mockRepository.SetupSequence(x => x.FilterBy(It.IsAny<Expression<Func<OffersDocument, bool>>>(),
                                                      It.IsAny<int?>(),
                                                      It.IsAny<int?>(),
                                                      It.IsAny<CancellationToken>()))
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList())
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList())
                       .ReturnsAsync(_documents.Skip(pageNumber).Take(pageSize).ToList());

        return this;
    }

    public GetOffersReceivedByArtistTestData SetupMockRepositoryNotFound()
    {
        _mockRepository.SetupSequence(x => x.CountAsync(It.IsAny<Expression<Func<OffersDocument, bool>>>(),
                                                        It.IsAny<CancellationToken>()))
                       .ReturnsAsync(0)
                       .ReturnsAsync(0);

        _mockRepository.SetupSequence(x => x.FilterBy(It.IsAny<Expression<Func<OffersDocument, bool>>>(),
                                                      It.IsAny<int?>(),
                                                      It.IsAny<int?>(),
                                                      It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new List<OffersDocument>())
                       .ReturnsAsync(new List<OffersDocument>());

        return this;
    }

    protected GetOffersReceivedByArtistRequest CreateRequest(int userId, int pageNumber, int pageSize)
    {
        return new GetOffersReceivedByArtistRequest(userId, new PaginationParameters(pageNumber, pageSize, string.Empty));
    }

    public GetOffersReceivedByArtistHandler Build()
    {
        return new GetOffersReceivedByArtistHandler(_mockRepository.Object, _mockCacheService.Object);
    }
}