namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress;

public class GetArtistByWalletAddressTestData
{
    private readonly Mock<IRepository<ArtistDocument>> MockRepository;
    private readonly Mock<ILogger<GetArtistByWalletAddressHandler>> MockLogger;
    private ArtistDocument? artistDocument;

    protected GetArtistByWalletAddressTestData()
    {
        MockRepository = new Mock<IRepository<ArtistDocument>>();
        MockLogger = new Mock<ILogger<GetArtistByWalletAddressHandler>>();
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

    protected GetArtistByWalletAddressTestData SetupMockRepository()
    {
        MockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByWalletAddressTestData SetupMockRepositoryNotFound()
    {
        artistDocument = null;

        MockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    protected GetArtistByWalletAddressTestData SetupMockRepositoryThrowsArgumentNullException()
    {
        MockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))
                      .ThrowsAsync(It.IsAny<ArgumentNullException>());

        return this;
    }

    protected GetArtistByWalletAddressRequest CreateRequest(string UserWalletAddress)
    {
        return new GetArtistByWalletAddressRequest(UserWalletAddress);
    }

    public GetArtistByWalletAddressHandler Build()
    {
        return new GetArtistByWalletAddressHandler(MockRepository.Object, MockLogger.Object);
    }
}