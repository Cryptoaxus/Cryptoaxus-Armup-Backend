namespace CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Request;

public class DeleteNftCollectionByIdRequest : IRequest<DeleteNftCollectionByIdResponse>
{
    internal ObjectId Id { get; set; }

    public DeleteNftCollectionByIdRequest(string id) => Id = id.ToObjectId();
}