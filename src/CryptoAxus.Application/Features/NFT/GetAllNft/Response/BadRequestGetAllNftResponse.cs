namespace CryptoAxus.Application.Features.NFT.GetAllNft.Response;

public class BadRequestGetAllNftResponse : BaseResponse<object>
{
    public BadRequestGetAllNftResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType) { }
}