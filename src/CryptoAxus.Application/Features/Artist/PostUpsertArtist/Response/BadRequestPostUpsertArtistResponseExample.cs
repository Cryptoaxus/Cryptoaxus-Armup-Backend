namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Response;

public class BadRequestPostUpsertArtistResponseExample : IExamplesProvider<BadRequestPostUpsertArtistResponse>
{
    public BadRequestPostUpsertArtistResponse GetExamples()
    {
        return new BadRequestPostUpsertArtistResponse("Unable to update artist.");
    }
}