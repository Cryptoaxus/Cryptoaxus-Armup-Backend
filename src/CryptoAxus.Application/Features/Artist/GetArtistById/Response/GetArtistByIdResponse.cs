namespace CryptoAxus.Application.Features.Artist.GetArtistById.Response;

public class GetArtistByIdResponse : BaseResponse<ArtistDto>
{
    public GetArtistByIdResponse()
    {
    }

    public GetArtistByIdResponse(HttpStatusCode statusCode, string? message, ArtistDto? result) : base(statusCode, message, result)
    {
    }
}