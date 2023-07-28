namespace CryptoAxus.Application.Features.NFT.PutNft.Response;

public class PutNftResponse : BaseResponse<NftDto>
{
    public PutNftResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }

    public PutNftResponse(HttpStatusCode statusCode, string? message, NftDto result) : this(statusCode, message) => Result = result;
}