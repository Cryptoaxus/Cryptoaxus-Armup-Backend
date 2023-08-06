namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Request;

public class GetNftCollectionByIdRequest : IRequest<GetNftCollectionByIdResponse>
{
    internal ObjectId Id { get; set; }

    public GetNftCollectionByIdRequest(string id) => Id = id.ToObjectId();
}