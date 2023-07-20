namespace CryptoAxus.Application.Features.Artist.GetArtistById;

public class GetArtistByIdTestData
{
    private readonly Mock<IRepository<ArtistDocument>> MockRepository;
    private readonly Mock<ILogger<GetArtistByIdQueryHandler>> MockLogger;
    private ArtistDocument? artistDocument;

    protected GetArtistByIdTestData()
    {
        MockRepository = new Mock<IRepository<ArtistDocument>>();
        MockLogger = new Mock<ILogger<GetArtistByIdQueryHandler>>();
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
                                             50719);
    }

    protected GetArtistByIdTestData SetupMockRepository()
    {
        MockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByIdTestData SetupMockRepositoryNotFound()
    {
        artistDocument = null;

        MockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByIdTestData SetupMockRepositoryThrowsArgumentNullException()
    {
        MockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                      .ThrowsAsync(It.IsAny<ArgumentNullException>());

        return this;
    }

    protected GetArtistByIdRequest CreateQuery(string id)
    {
        return new GetArtistByIdRequest(id);
    }

    public GetArtistByIdQueryHandler Build()
    {
        return new GetArtistByIdQueryHandler(MockRepository.Object, MockLogger.Object);
    }
}