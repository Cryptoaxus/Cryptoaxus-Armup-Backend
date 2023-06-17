namespace CryptoAxus.Application.Features.Artist.DeleteArtistById;

public class DeleteArtistByIdTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private const string Id = "647115d2b38bc8ea242beb01";

    protected DeleteArtistByIdTestsData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
    }

    protected DeleteArtistByIdTestsData SetupMockRepository()
    {
        DeleteResult result = new DeleteResult.Acknowledged(1);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                       .ReturnsAsync(new ArtistDocument());

        _mockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(result);

        return this;
    }

    protected DeleteArtistByIdTestsData SetupMockRepositoryArtistNotFound()
    {
        ArtistDocument? artistDocument = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(artistDocument);

        return this;
    }

    public DeleteArtistByIdTestsData DeleteCountIsZero()
    {
        DeleteResult result = new DeleteResult.Acknowledged(0);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                       .ReturnsAsync(new ArtistDocument());

        _mockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(result);

        return this;
    }

    protected DeleteArtistByIdRequest CreateRequest(string id)
    {
        return new DeleteArtistByIdRequest(id);
    }

    public DeleteArtistByIdHandler Build()
    {
        return new DeleteArtistByIdHandler(_mockRepository.Object);
    }
}