namespace CryptoAxus.Application.Features.NFT.GetNftById.Response;

public class NotFoundGetNftByIdResponse : BaseResponse<NftDto>
{
    public NotFoundGetNftByIdResponse(string? message) : base(HttpStatusCode.NotFound, message) { }
}