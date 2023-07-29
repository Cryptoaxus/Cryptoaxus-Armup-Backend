namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Request;

public class PutLikeFavoriteNftRequest : IRequest<PutLikeFavoriteNftResponse>
{
    internal LikeFavoriteTypeEnum Type { get; set; }

    internal string NftId { get; set; }

    internal string UserId { get; set; }

    public PutLikeFavoriteNftRequest(LikeFavoriteTypeEnum type, string nftId, string userId) =>
                                    (Type, NftId, UserId) = (type, nftId, userId);
}