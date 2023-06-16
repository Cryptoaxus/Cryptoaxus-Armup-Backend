namespace CryptoAxus.Application.Features.DeleteArtistById.Response;

public class NotFoundDeleteArtistByIdResponse : BaseResponse<ArtistDto>
{
    public NotFoundDeleteArtistByIdResponse() : base()
    {
    }

    public NotFoundDeleteArtistByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}