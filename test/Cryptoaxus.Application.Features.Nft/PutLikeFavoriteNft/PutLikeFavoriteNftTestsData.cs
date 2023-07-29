namespace CryptoAxus.Application.Features.Nft.PutLikeFavoriteNft;

public class PutLikeFavoriteNftTestsData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private NftDocument? mockDocument;

    public PutLikeFavoriteNftTestsData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        mockDocument = new NftDocument(ObjectId.GenerateNewId(), "contractAddress", "hash",
                                       "https://www.google.com", "signature", 24526, 10, "Mock Nft",
                                       "https://www.google.com", "Mock Description", "Mock Collection",
                                       ObjectId.GenerateNewId(), "Ethereum", 450, ObjectId.GenerateNewId(),
                                       new List<string>
                                       {
                                           "64c5357e1e4e37e918060a7f", "64c5357e1e4e37e918060a80", "64c5357e1e4e37e918060a81",
                                           "64c5357e1e4e37e918060a82", "64c5357e1e4e37e918060a83", "64c536051e4e37e918060a84"
                                       },
                                       new List<string>
                                       {
                                           "64c5357e1e4e37e918060a7f", "64c5357e1e4e37e918060a80", "64c5357e1e4e37e918060a81",
                                           "64c5357e1e4e37e918060a82", "64c5357e1e4e37e918060a83", "64c536051e4e37e918060a84"
                                       });
    }

    public PutLikeFavoriteNftTestsData SetupMockRepositoryFindOneAsync(bool exist)
    {
        if (!exist)
            mockDocument = null;

        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))!
                       .ReturnsAsync(mockDocument);

        return this;
    }

    public PutLikeFavoriteNftTestsData SetupMockRepositoryUpdateOneAsync(bool updated)
    {
        UpdateResult updateResult = new UpdateResult.Acknowledged(1, 1, ObjectId.GenerateNewId());

        if (!updated)
            updateResult = new UpdateResult.Acknowledged(1, 0, null);

        _mockRepository.Setup(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<NftDocument>>(), It.IsAny<UpdateDefinition<NftDocument>>()))
                       .ReturnsAsync(updateResult);

        return this;
    }

    public PutLikeFavoriteNftRequest CreateRequest(LikeFavoriteTypeEnum type, string nftId, string userId)
    {
        return new PutLikeFavoriteNftRequest(type, nftId, userId);
    }

    public PutLikeFavoriteNftHandler Build()
    {
        return new PutLikeFavoriteNftHandler(_mockRepository.Object);
    }
}