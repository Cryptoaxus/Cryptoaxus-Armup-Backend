using CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Handler;
using CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Request;

namespace CryptoAxus.Application.Features.Nft.GetLikeFavoriteNftByArtist;

public class GetLikeFavoriteNftByArtistTestsData
{
    private readonly Mock<IRepository<NftDocument>> _mockRepository;
    private List<NftDocument>? _mockDocuments;

    protected GetLikeFavoriteNftByArtistTestsData()
    {
        _mockRepository = new Mock<IRepository<NftDocument>>();
        _mockDocuments = new List<NftDocument>
        {
            new NftDocument(ObjectId.GenerateNewId(), "contractAddress", "hash", "https://www.google.com",
                            "signature", 45268, 10, "Example Nft", "https://www.google.com",
                            "Example description", "Example Collection", ObjectId.GenerateNewId().ToString(),
                            "Ethereum", 450, ObjectId.GenerateNewId(),
                            new List<string> { ObjectId.GenerateNewId().ToString() },
                            new List<string> { ObjectId.GenerateNewId().ToString() }),
            new NftDocument(ObjectId.GenerateNewId(), "contractAddress", "hash", "https://www.google.com",
                            "signature", 45268, 10, "Example Nft", "https://www.google.com",
                            "Example description", "Example Collection", ObjectId.GenerateNewId().ToString(),
                            "Ethereum", 450, ObjectId.GenerateNewId(),
                            new List<string> { ObjectId.GenerateNewId().ToString() },
                            new List<string> { ObjectId.GenerateNewId().ToString() }),
            new NftDocument(ObjectId.GenerateNewId(), "contractAddress", "hash", "https://www.google.com",
                            "signature", 45268, 10, "Example Nft", "https://www.google.com",
                            "Example description", "Example Collection", ObjectId.GenerateNewId().ToString(),
                            "Ethereum", 450, ObjectId.GenerateNewId(),
                            new List<string> { ObjectId.GenerateNewId().ToString() },
                            new List<string> { ObjectId.GenerateNewId().ToString() })
        };
    }

    protected GetLikeFavoriteNftByArtistTestsData SetupMockRepository(bool exist)
    {
        if (!exist)
            _mockDocuments = new List<NftDocument>();

        _mockRepository.Setup(x => x.FilterBy(It.IsAny<Expression<Func<NftDocument, bool>>>(),
                                              null,
                                              null,
                                              It.IsAny<CancellationToken>()))!
                       .ReturnsAsync(_mockDocuments);

        return this;
    }

    protected GetLikeFavoriteNftByArtistRequest CreateRequest()
    {
        return new GetLikeFavoriteNftByArtistRequest(ObjectId.GenerateNewId().ToString());
    }

    public GetLikeFavoriteNftByArtistHandler Build()
    {
        return new GetLikeFavoriteNftByArtistHandler(_mockRepository.Object);
    }
}