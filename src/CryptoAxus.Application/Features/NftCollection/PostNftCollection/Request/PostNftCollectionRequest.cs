namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Request;

public class PostNftCollectionRequest : IRequest<PostNftCollectionResponse>
{
    public CreateNftCollectionsDto NftCollection { get; set; }

    public PostNftCollectionRequest(CreateNftCollectionsDto dto) => NftCollection = dto;
}