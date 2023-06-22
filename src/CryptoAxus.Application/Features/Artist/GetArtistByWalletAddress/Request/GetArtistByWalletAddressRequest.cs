namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Request;

public class GetArtistByWalletAddressRequest : IRequest<GetArtistByWalletAddressResponse>
{
    internal string UserWalletAddress { get; private set; }

    public GetArtistByWalletAddressRequest()
    {
    }

    public GetArtistByWalletAddressRequest(string userWalletAddress) => UserWalletAddress = userWalletAddress;
}