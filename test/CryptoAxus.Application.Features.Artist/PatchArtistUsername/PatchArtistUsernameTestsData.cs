namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername;

public class PatchArtistUsernameTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private ArtistDocument? _artistDocument;
    private const string Id = "507f191e810c19729de860ea";

    protected PatchArtistUsernameTestsData()
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

    protected PatchArtistUsernameTestsData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    protected PatchArtistUsernameTestsData SetupMockRepositoryArtistNotFound()
    {
        _artistDocument = null;
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    public PatchArtistUsernameTestsData SetupMockRepositoryUpdateOneAsync()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 1, Id);

        _mockRepository.Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<ArtistDocument>>(), It.IsAny<UpdateDefinition<ArtistDocument>>()))!
                       .ReturnsAsync(updateResult);

        return this;
    }

    public PatchArtistUsernameTestsData SetupMockRepositoryReturnsBadRequest()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 0, Id);

        _mockRepository
               .Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<ArtistDocument>>(), It.IsAny<UpdateDefinition<ArtistDocument>>()))
               .ReturnsAsync(updateResult);

        return this;
    }

    protected static PatchArtistUsernameRequest CreateRequest()
    {
        JsonPatchDocument<ArtistDto> patchDocument = new JsonPatchDocument<ArtistDto>();
        Operation<ArtistDto> operation = new Operation<ArtistDto>
        {
            op = "replace",
            path = "/username",
            value = "test.username"
        };
        patchDocument.Operations.Add(operation);

        return new PatchArtistUsernameRequest("0x507f191e810c19729de860ea", patchDocument);
    }

    public PatchArtistUsernameHandler Build()
    {
        return new PatchArtistUsernameHandler(_mockRepository.Object);
    }
}