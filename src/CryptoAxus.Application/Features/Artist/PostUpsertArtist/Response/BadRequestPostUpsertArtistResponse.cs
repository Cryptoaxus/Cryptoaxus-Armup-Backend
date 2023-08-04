namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Response;

public class BadRequestPostUpsertArtistResponse : PostUpsertArtistResponse
{
    public BadRequestPostUpsertArtistResponse(string? message) : base(HttpStatusCode.BadRequest, message)
    {
    }
}