namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Response;

public class NotFoundGetNftCollectionsByWalletAddressResponse : GetNftCollectionsByWalletAddressResponse
{
    public NotFoundGetNftCollectionsByWalletAddressResponse(string walletAddress)
            : base(HttpStatusCode.NotFound, $"No records found against wallet address: {walletAddress}.")
    {
    }
}