namespace CryptoAxus.Application.Features.DeleteArtistById.Response;

public class DeleteArtistByIdResponse : BaseResponse<ArtistDto>
{
    public DeleteArtistByIdResponse()
    {
    }

    public DeleteArtistByIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}
