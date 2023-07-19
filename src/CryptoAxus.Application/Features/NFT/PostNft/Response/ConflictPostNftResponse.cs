namespace CryptoAxus.Application.Features.NFT.PostNft.Response;

public class ConflictPostNftResponse : BaseResponse<NftDto>
{
    public ConflictPostNftResponse() : base(HttpStatusCode.Conflict, "Nft with same id already exists.")
    {
    }

    public ConflictPostNftResponse(NftDto result) : this() => Result = result;
}