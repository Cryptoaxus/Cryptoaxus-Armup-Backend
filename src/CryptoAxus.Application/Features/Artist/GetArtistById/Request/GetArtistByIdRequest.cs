namespace CryptoAxus.Application.Features.Artist.GetArtistById.Request;

public class GetArtistByIdRequest : IRequest<GetArtistByIdResponse>
{
    internal string Id { get; private set; }

    public GetArtistByIdRequest()
    {
    }

    public GetArtistByIdRequest(string id) => Id = id;
}