namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;

public class GetArtistByUserIdRequestExample : IExamplesProvider<GetArtistByUserIdRequest>
{
    public GetArtistByUserIdRequest GetExamples()
    {
        return new GetArtistByUserIdRequest(6471);
    }
}