namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class GetArtistByUserIdResponse : BaseResponse<ArtistDto>
{
    public GetArtistByUserIdResponse()
    {
    }

    public GetArtistByUserIdResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetArtistByUserIdResponse(HttpStatusCode statusCode, string? message, ArtistDto? result) : this(statusCode, message)
    {
        Result = result;
    }
    
}