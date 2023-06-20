using CryptoAxus.Common.Services.Contracts;

namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class NotFoundArtistByWalletAddressResponseExample : IOpenApiExampleProvider<NotFoundArtistByWalletAddressResponse>
{
    public object Example()
    {
        return new NotFoundArtistByWalletAddressResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against id: 0x647115d2b38bc8ea242beb01",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}