namespace CryptoAxus.Application.Features.NFT.GetNftById.Response;

public class BadRequestGetNftByIdResponse : BaseResponse<NftDto>
{
    public BadRequestGetNftByIdResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType) { }
}