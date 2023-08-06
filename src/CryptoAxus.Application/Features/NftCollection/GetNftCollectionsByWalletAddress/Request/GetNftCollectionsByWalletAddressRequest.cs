namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Request;

public class GetNftCollectionsByWalletAddressRequest : IRequest<GetNftCollectionsByWalletAddressResponse>
{
    internal string WalletAddress { get; set; }

    public GetNftCollectionsByWalletAddressRequest(string walletAddress) => WalletAddress = walletAddress;
}