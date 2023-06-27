namespace CryptoAxus.Application.Features.Artist.PatchArtistWalletAddress;

public class PatchArtistTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private ArtistDocument? _artistDocument;
    private const string Id = "507f191e810c19729de860ea";

    protected PatchArtistTestsData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
        _artistDocument = new ArtistDocument(Id.ToObjectId(),
                                            "testUsername",
                                            "test@nftarmup.com",
                                            "0x507f191e810c19729de860ea",
                                            "https://www.google.com",
                                            "testBio",
                                            "testProfileImageAddress",
                                            "testCoverImageAddress",
                                            "instagramLink",
                                            "twitterLink",
                                            Id.ToObjectId());
    }

    protected PatchArtistTestsData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    protected PatchArtistTestsData SetupMockRepositoryArtistNotFound()
    {
        _artistDocument = null;
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    public PatchArtistTestsData SetupMockRepositoryUpdateOneAsync()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 1, Id);

        _mockRepository.Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<ArtistDocument>>(), It.IsAny<UpdateDefinition<ArtistDocument>>()))!
                       .ReturnsAsync(updateResult);

        return this;
    }

    public PatchArtistTestsData SetupMockRepositoryReturnsBadRequest()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 0, Id);

        _mockRepository
               .Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<ArtistDocument>>(), It.IsAny<UpdateDefinition<ArtistDocument>>()))
               .ReturnsAsync(updateResult);

        return this;
    }

    public PatchArtistRequest CreateRequest()
    {
        return new PatchArtistRequest(new UpdateArtistDto("tom.cruise",
                                                         "tom.cruise@armup.com",
                                                         "0x51c330436F289192F43666e51Df72Ec06F66Dad9",
                                                         "https://www.tomcruise.com",
                                                         "Versatile actor",
                                                         "tom-cruise.png",
                                                         "tom-cruise-cover.png",
                                                         "https://www.instagram.com/tomcruise",
                                                         "https://www.twitter.com/tomcruise"));
    }

    public PatchArtistHandler Build()
    {
        return new PatchArtistHandler(_mockRepository.Object);
    }
}
