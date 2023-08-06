namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Response;

public class BadRequestGetNftCollectionsByWalletAddressResponse : GetNftCollectionsByWalletAddressResponse
{
    public BadRequestGetNftCollectionsByWalletAddressResponse() : base(HttpStatusCode.BadRequest, Messages.InvalidMediaType)
    {
    }
}