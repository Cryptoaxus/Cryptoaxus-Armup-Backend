namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;

public class BadRequestGetOffersReceivedByArtistResponseExample : IExamplesProvider<BadRequestGetOffersReceivedByArtistResponse>
{
    public BadRequestGetOffersReceivedByArtistResponse GetExamples()
    {
        return new BadRequestGetOffersReceivedByArtistResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Invalid media type provided",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}