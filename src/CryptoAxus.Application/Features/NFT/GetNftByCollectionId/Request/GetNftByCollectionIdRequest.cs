namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Request;

public class GetNftByCollectionIdRequest : IRequest<GetNftByCollectionIdResponse>
{
    internal string CollectionId { get; set; }

    public GetNftByCollectionIdRequest(string collectionId) => CollectionId = collectionId;
}