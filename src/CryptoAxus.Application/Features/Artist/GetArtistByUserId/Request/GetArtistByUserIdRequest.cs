namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;

public class GetArtistByUserIdRequest : IRequest<GetArtistByUserIdResponse>
{
    internal int UserId { get; private set; }

    public GetArtistByUserIdRequest()
    {
    }

    public GetArtistByUserIdRequest(int userId) => UserId = userId;
}