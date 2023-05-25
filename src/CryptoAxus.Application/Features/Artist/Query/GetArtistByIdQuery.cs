namespace CryptoAxus.Application.Features.Artist.Query;

public class GetArtistByIdQuery : IRequest<BaseResponse<ArtistDto>>
{
    internal string Id { get; private set; }

    public GetArtistByIdQuery(string id)
    {
        Id = id;
    }
}