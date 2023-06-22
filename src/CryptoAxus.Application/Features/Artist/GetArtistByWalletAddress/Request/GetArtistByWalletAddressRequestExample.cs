namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Request;

public class GetArtistByWalletAddressRequestExample : IExamplesProvider<GetArtistByWalletAddressRequest>
{
    public GetArtistByWalletAddressRequest GetExamples()
    {
        return new GetArtistByWalletAddressRequest("0x647115d2b38bc8ea242beb01");
    }
}