namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;

public class NotFoundDeleteArtistByIdResponseExample : IExamplesProvider<NotFoundDeleteArtistByIdResponse>
{
    public NotFoundDeleteArtistByIdResponse GetExamples()
    {
        return new NotFoundDeleteArtistByIdResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against id: 647115d2b38bc8ea242beb01",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}