using CryptoAxus.Application.Features.DeleteArtistById.Handler;
using CryptoAxus.Application.Features.DeleteArtistById.Request;
using MongoDB.Bson;
using Moq;

public class DeleteArtistByIdTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> MockRepository;
    private ArtistDocument? _artistDocument;
    private const string Id = "647115d2b38bc8ea242beb01";

    protected DeleteArtistByIdTestsData()
    {
        MockRepository = new Mock<IRepository<ArtistDocument>>();
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

    protected DeleteArtistByIdTestsData SetupMockRepository()
    {
        MockRepository.Setup(x => x.FindOneAsync(It.IsAny<Expression<Func<ArtistDocument, bool>>>()))!
                       .ReturnsAsync(_artistDocument);

        return this;
    }

    protected DeleteArtistByIdTestsData SetupMockRepositoryArtistNotFound()
    {
        _artistDocument = null;
        MockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(_artistDocument);

        return this;
    }

    public DeleteArtistByIdTestsData SetupMockRepositoryDeleteOneAsync()
    {
        MockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).Returns(It.IsAny<Delegate>());

        return this;
    }

    public DeleteArtistByIdTestsData SetupMockRepositoryReturnsBadRequest()
    {
        MockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).ThrowsAsync(new Exception("Invalid - Bad Request"));
        return this;
    }

    protected DeleteArtistByIdRequest CreateQuery(string id)
    {
        return new DeleteArtistByIdRequest(id);
    }

    public DeleteArtistByIdHandler Build()
    {
        return new DeleteArtistByIdHandler(MockRepository.Object);
    }
}