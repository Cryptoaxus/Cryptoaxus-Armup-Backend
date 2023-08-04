namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Request;

public class PostNftCollectionRequest : IRequest<PostNftCollectionResponse>
{
    internal CreateNftCollectionsDto NftCollection { get; set; }

    public PostNftCollectionRequest(CreateNftCollectionsDto dto) => NftCollection = dto;
}