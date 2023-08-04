namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Response;

public class ConflictPostUpsertArtistResponse : PostUpsertArtistResponse
{
    public ConflictPostUpsertArtistResponse() : base(HttpStatusCode.Conflict, "Artist with same user id or wallet address already exist.")
    {
    }
}