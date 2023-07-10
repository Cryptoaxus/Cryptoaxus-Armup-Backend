namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist;

public class GetOffersRecivedByArtistTestData
{
    private readonly Mock<IRepository<OffersDocument>> _mockRepository;
    private readonly Mock<ICacheService> _mockCacheService;
    private readonly List<OffersDocument> _documents;
    protected GetOffersRecivedByArtistTestData()
    {
        _mockRepository = new Mock<IRepository<OffersDocument>>();
        _mockCacheService = new Mock<ICacheService>();
        _documents = new List<OffersDocument> {
             new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5,
                               ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId()),

            new OffersDocument(ObjectId.GenerateNewId(),
                               "nftId",
                               Convert.ToDecimal(50.45),
                               248,
                               547,
                               10,
                               DateTime.UtcNow.AddHours(6),
                               5, ObjectId.GenerateNewId())
        };
    }

    public GetOffersRecivedByArtistTestData SetupMockCacheService()
    {
        _mockCacheService.Setup(x => x.GetAsync<string?>(It.IsAny<string>()))
                         .ReturnsAsync("Cached value");

        _mockCacheService.Setup(x => x.SetAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        return this;
    }


    public GetOffersRecivedByArtistTestData SetupMockCacheServiceExists()
    {
        _mockCacheService.Setup(x => x.GetAsync<GetOffersRecivedByArtistResponse>(It.IsAny<string>()))
                         .ReturnsAsync(new GetOffersRecivedByArtistResponse(HttpStatusCode.OK,
                                                                            "Records found successfully.",
                                                                            _documents.Adapt<List<OffersDto>>(),
                                                                            new PaginationData(100, 1, 25)));
        return this;
    }

    public GetOffersRecivedByArtistTestData SetupMockRepository(int pageNumber, int pageSize)
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
    public GetOffersRecivedByArtistTestData SetupMockRepositoryNotFound()
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

    protected GetOffersRecivedByArtistRequest CreateRequest(int userId, int pageNumber, int pageSize)
    {
        return new GetOffersRecivedByArtistRequest(userId, new PaginationParameters(pageNumber, pageSize, string.Empty));
    }

    public GetOffersRecivedByArtistHandler Build()
    {
        return new GetOffersRecivedByArtistHandler(_mockRepository.Object, _mockCacheService.Object);
    }
}