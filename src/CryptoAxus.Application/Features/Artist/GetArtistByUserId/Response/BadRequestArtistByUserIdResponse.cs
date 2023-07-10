namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class BadRequestArtistByUserIdResponse : BaseResponse<ArtistDto>
{
    public BadRequestArtistByUserIdResponse() : base()
    {
    }

    public BadRequestArtistByUserIdResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
    }
}