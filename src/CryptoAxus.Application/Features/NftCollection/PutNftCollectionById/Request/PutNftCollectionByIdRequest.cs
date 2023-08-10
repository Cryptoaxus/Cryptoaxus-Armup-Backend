namespace CryptoAxus.Application.Features.NftCollection.PutNftCollectionById.Request;

public class PutNftCollectionByIdRequest : IRequest<PutNftCollectionByIdResponse>
{
    internal ObjectId Id { get; set; }

    internal UpdateNftCollectionDto Dto { get; set; }
}