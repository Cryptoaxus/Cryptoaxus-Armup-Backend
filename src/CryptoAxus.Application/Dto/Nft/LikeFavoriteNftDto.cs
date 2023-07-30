namespace CryptoAxus.Application.Dto.Nft;

public class LikeFavoriteNftDto
{
    public IEnumerable<NftDto>? LikedNft { get; set; }

    public IEnumerable<NftDto>? FavoriteNft { get; set; }

    public int? LikedCount { get; set; }

    public int? FavoriteCount { get; set; }

    public LikeFavoriteNftDto(IEnumerable<NftDto>? likedNft, IEnumerable<NftDto>? favoriteNft)
    {
        LikedNft = likedNft;
        FavoriteNft = favoriteNft;
        LikedCount = LikedNft?.Count();
        FavoriteCount = FavoriteNft?.Count();
    }
}