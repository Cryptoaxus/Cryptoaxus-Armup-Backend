namespace CryptoAxus.Application.Features.NFT.PostNft.Request;

public class PostNftRequest : IRequest<PostNftResponse>
{
    public CreateNftDto Nft { get; set; }

    public PostNftRequest(CreateNftDto nft) => Nft = nft;
}