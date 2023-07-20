namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId;

public class GetArtistByUserIdTestData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private readonly Mock<ILogger<GetArtistByUserIdHandler>> _mockLogger;
    private ArtistDocument? artistDocument;

    protected GetArtistByUserIdTestData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
        _mockLogger = new Mock<ILogger<GetArtistByUserIdHandler>>();
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
                                             ObjectId.GenerateNewId());
    }

    protected GetArtistByUserIdTestData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))!
                       .ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByUserIdTestData SetupMockRepositoryNotFound()
    {
        artistDocument = null;

        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))!
                      .ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByUserIdTestData SetupMockRepositoryThrowsArgumentNullException()
    {
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))
                      .ThrowsAsync(It.IsAny<ArgumentNullException>());

        return this;
    }

    protected GetArtistByUserIdRequest CreateRequest(int userId)
    {
        return new GetArtistByUserIdRequest(userId);
    }

    public GetArtistByUserIdHandler Build()
    {
        return new GetArtistByUserIdHandler(_mockRepository.Object, _mockLogger.Object);
    }
}