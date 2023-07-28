namespace CryptoAxus.Application.Features.NFT.PutNft.Request;

public class PutNftRequest : IRequest<PutNftResponse>
{
    internal ObjectId Id { get; set; }

    public UpdateNftDto NftDto { get; set; }

    public PutNftRequest(string? id, UpdateNftDto nftDto) => (Id, NftDto) = (id.ToObjectId(), nftDto);
}