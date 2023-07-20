namespace CryptoAxus.Application.Features.Artist.PatchArtist;

public class PatchArtistTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private ArtistDocument? _artistDocument;
    private const int Id = 50719;

    protected PatchArtistTestsData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
        _artistDocument = new ArtistDocument(ObjectId.GenerateNewId(),
                                            "testUsername",
                                            "test@nftarmup.com",
                                            5071,
                                            "https://www.google.com",
                                            "testBio",
                                            "testProfileImageAddress",
                                            "testCoverImageAddress",
                                            "instagramLink",
                                            "twitterLink",
                                            Id);
    }

    protected PatchArtistTestsData SetupMockRepository()
    {
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    protected PatchArtistTestsData SetupMockRepositoryArtistNotFound()
    {
        _artistDocument = null;
        _mockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))!
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
        JsonPatchDocument<UpdateArtistDto> patchDocument = new JsonPatchDocument<UpdateArtistDto>();
        Operation<UpdateArtistDto> operation = new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/username",
            value = "test.username"
        };
        patchDocument.Operations.Add(operation);

        return new PatchArtistRequest(5071, patchDocument);
    }

    public PatchArtistHandler Build()
    {
        return new PatchArtistHandler(_mockRepository.Object);
    }
}
