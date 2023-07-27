namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Request;

public class DeleteNftByIdRequest : IRequest<DeleteNftByIdResponse>
{
    internal ObjectId Id { get; set; }

    public DeleteNftByIdRequest(string id) => Id = id.ToObjectId();
}