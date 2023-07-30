namespace CryptoAxus.Application.Features.Artist.GetArtistById;

public class GetArtistByIdTestData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private readonly Mock<ILogger<GetArtistByIdQueryHandler>> _mockLogger;
    private ArtistDocument? artistDocument;

    protected GetArtistByIdTestData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
        _mockLogger = new Mock<ILogger<GetArtistByIdQueryHandler>>();
        artistDocument = new ArtistDocument("507f191e810c19729de860ea".ToObjectId(),
                                             "testUsername",
                                             "test@nftarmup.com",
                                             5071,
                                             "https://www.google.com",
                                             "testBio",
                                             "testProfileImageAddress",
                                             "testCoverImageAddress",
                                             "instagramLink",
                                             "twitterLink",
                                             ObjectId.GenerateNewId().ToString());
    }

    protected GetArtistByIdTestData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByIdTestData SetupMockRepositoryNotFound()
    {
        artistDocument = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByIdTestData SetupMockRepositoryThrowsArgumentNullException()
    {
        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                      .ThrowsAsync(It.IsAny<ArgumentNullException>());

        return this;
    }

    protected GetArtistByIdRequest CreateQuery(string id)
    {
        return new GetArtistByIdRequest(id);
    }

    public GetArtistByIdQueryHandler Build()
    {
        return new GetArtistByIdQueryHandler(_mockRepository.Object, _mockLogger.Object);
    }
}