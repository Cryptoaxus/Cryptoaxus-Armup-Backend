namespace CryptoAxus.Application.Features.Nft.PutNft;

public class PutNftTestsData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private ObjectId id;

    public PutNftTestsData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        id = ObjectId.GenerateNewId();
    }

    public PutNftTestsData SetupMockRepository()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 1, id);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(new NftDocument());

        _mockRepository.Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<NftDocument>>(),
                                                    It.IsAny<UpdateDefinition<NftDocument>>()))
                       .ReturnsAsync(updateResult);

        return this;
    }

    public PutNftTestsData SetupMockRepositoryNotFound()
    {
        NftDocument? document = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!.ReturnsAsync(document);

        return this;
    }

    public PutNftTestsData SetupMockRepositoryUnableToUpdate()
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 0, id);

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>())).ReturnsAsync(new NftDocument());

        _mockRepository.Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<NftDocument>>(),
                                                    It.IsAny<UpdateDefinition<NftDocument>>()))
                       .ReturnsAsync(updateResult);

        return this;
    }

    public PutNftRequest CreateRequest()
    {
        return new PutNftRequest(ObjectId.GenerateNewId().ToString(),
                                 new UpdateNftDto("Contract Address",
                                                  "Hash",
                                                  "https://www.google.com/",
                                                  "Signature",
                                                  450,
                                                  10,
                                                  "Example Nft",
                                                  "https://www.google.com/",
                                                  "Example Description",
                                                  "Example Collection",
                                                  ObjectId.GenerateNewId().ToString(),
                                                  "Ethereum",
                                                  100,
                                                  ObjectId.GenerateNewId().ToString()));
    }

    public PutNftHandler Build()
    {
        return new PutNftHandler(_mockRepository.Object);
    }
}