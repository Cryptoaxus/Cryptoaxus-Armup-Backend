namespace CryptoAxus.Application.Features.Nft.DeleteNftById;

public class DeleteNftByIdTestsData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;

    public DeleteNftByIdTestsData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
    }

    protected DeleteNftByIdTestsData SetupMockRepository()
    {
        DeleteResult result = new DeleteResult.Acknowledged(1);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                       .ReturnsAsync(new NftDocument());

        _mockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(result);

        return this;
    }

    protected DeleteNftByIdTestsData SetupMockRepositoryArtistNotFound()
    {
        NftDocument? nftDocument = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(nftDocument);

        return this;
    }

    public DeleteNftByIdTestsData DeleteCountIsZero()
    {
        DeleteResult result = new DeleteResult.Acknowledged(0);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                       .ReturnsAsync(new NftDocument());

        _mockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(result);

        return this;
    }

    protected DeleteNftByIdRequest CreateRequest(string id)
    {
        return new DeleteNftByIdRequest(id);
    }

    public DeleteNftByIdHandler Build()
    {
        return new DeleteNftByIdHandler(_mockRepository.Object);
    }
}