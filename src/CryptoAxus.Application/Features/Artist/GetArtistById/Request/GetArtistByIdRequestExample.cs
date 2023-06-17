namespace CryptoAxus.Application.Features.Artist.GetArtistById.Request;

public class GetArtistByIdRequestExample : IExamplesProvider<GetArtistByIdRequest>
{
    public GetArtistByIdRequest GetExamples()
    {
        return new GetArtistByIdRequest("507f191e810c19729de860ea");
    }
}