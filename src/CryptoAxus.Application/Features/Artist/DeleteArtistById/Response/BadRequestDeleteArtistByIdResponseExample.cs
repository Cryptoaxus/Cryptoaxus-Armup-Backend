namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Response;

public class BadRequestDeleteArtistByIdResponseExample : IExamplesProvider<BadRequestDeleteArtistByIdResponse>
{
    public BadRequestDeleteArtistByIdResponse GetExamples()
    {
        return new BadRequestDeleteArtistByIdResponse
        {
            ApiException = null,
            Links = null,
            Errors = null,
            IsSuccessful = false,
            Message = "Unable to delete artist against id: 647115d2b38bc8ea242beb01",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}