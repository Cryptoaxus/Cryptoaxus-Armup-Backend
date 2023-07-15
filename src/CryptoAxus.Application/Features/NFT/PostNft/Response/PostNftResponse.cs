namespace CryptoAxus.Application.Features.NFT.PostNft.Response;

public class PostNftResponse : BaseResponse<NftDto>
{
    public PostNftResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public PostNftResponse(NftDto? result) : this(HttpStatusCode.Created, $"Nft created with id: {result?.Id}.") => Result = result;
}