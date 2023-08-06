namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Response;

public class GetNftCollectionsByWalletAddressResponse : BaseResponse<List<NftCollectionsDto>>
{
    public GetNftCollectionsByWalletAddressResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetNftCollectionsByWalletAddressResponse(List<NftCollectionsDto> result)
            : this(HttpStatusCode.OK, "Records found successfully.") => Result = result;
}