namespace CryptoAxus.Application.Features.NFT.PostNft.Response;

public class BadRequestPostNftResponse : BaseResponse<NftDto>
{
    public BadRequestPostNftResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}