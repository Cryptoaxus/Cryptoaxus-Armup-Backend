using CryptoAxus.Application.Features.Artist.GetArtistById.Handler;
using CryptoAxus.Application.Features.Artist.GetArtistById.Query;

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
                                             "0x507f191e810c19729de860ea",
                                             "https://www.google.com",
                                             "testBio",
                                             "testProfileImageAddress",
                                             "testCoverImageAddress",
                                             "instagramLink",
                                             "twitterLink",
                                             "507f191e810c19729de860ea".ToObjectId());
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

    protected GetArtistByIdQuery CreateQuery(string id)
    {
        return new GetArtistByIdQuery(id);
    }

    public GetArtistByIdQueryHandler Build()
    {
        return new GetArtistByIdQueryHandler(MockRepository.Object, MockLogger.Object);
    }
}