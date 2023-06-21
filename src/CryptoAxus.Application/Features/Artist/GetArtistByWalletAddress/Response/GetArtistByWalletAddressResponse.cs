namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class GetArtistByWalletAddressResponse : BaseResponse<ArtistDto>
{
    public GetArtistByWalletAddressResponse()
    {
    }

    public GetArtistByWalletAddressResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetArtistByWalletAddressResponse(HttpStatusCode statusCode, string? message, ArtistDto? result) : this(statusCode, message)
    {
        Result = result;
    }
    
}