namespace CryptoAxus.Application.Features.Artist.GetArtistById.Response;

public class GetArtistByIdResponseExample : IExamplesProvider<GetArtistByIdResponse>
{
    public GetArtistByIdResponse GetExamples()
    {
        return new GetArtistByIdResponse(HttpStatusCode.OK, "Artist record found successfully", new ArtistDto());
    }
}