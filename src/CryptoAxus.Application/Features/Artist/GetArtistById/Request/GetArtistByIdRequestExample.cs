namespace CryptoAxus.Application.Features.Artist.GetArtistById.Request;

public class GetArtistByIdRequestExample : IExamplesProvider<GetArtistByIdRequest>
{
    public GetArtistByIdRequest GetExamples()
    {
        return new GetArtistByIdRequest();
    }
}