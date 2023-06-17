namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;

public class BadRequestDeleteArtistByIdResponse : BaseResponse<object>
{
    public BadRequestDeleteArtistByIdResponse()
    {
    }

    public BadRequestDeleteArtistByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}