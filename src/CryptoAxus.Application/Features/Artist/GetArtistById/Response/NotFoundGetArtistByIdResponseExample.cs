namespace CryptoAxus.Application.Features.Artist.GetArtistById.Response;

public class NotFoundGetArtistByIdResponseExample : IOpenApiExampleProvider<NotFoundGetArtistByIdResponse>
{
    public object Example()
    {
        return new NotFoundGetArtistByIdResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against id: 507f191e810c19729de860ea",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}