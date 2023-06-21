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
            Message = "No record found against userWalletAddress: 507f191e810c19729de860ea",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}