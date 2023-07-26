namespace CryptoAxus.Application.Features.Artist.PatchArtist.Request;

public class PatchArtistRequest : IRequest<PatchArtistResponse>
{
    internal int? UserId { get; set; }

    [JsonProperty("artist")]
    public JsonPatchDocument<UpdateArtistDto> ArtistDto { get; set; }

    public PatchArtistRequest(int? userId, JsonPatchDocument<UpdateArtistDto> artist) =>
                             (UserId, ArtistDto) = (userId, artist);

}