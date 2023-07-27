namespace CryptoAxus.Application.Features.NFT.GetAllNft.Response;

public class NotFoundGetAllNftResponse : BaseResponse<object>
{
    public NotFoundGetAllNftResponse() : base(HttpStatusCode.NotFound, "No nft record exists in the system.") { }
}