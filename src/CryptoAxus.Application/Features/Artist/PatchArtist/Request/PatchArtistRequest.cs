namespace CryptoAxus.Application.Features.Artist.PatchArtist.Request;

public class PatchArtistRequest : IRequest<PatchArtistResponse>
{
    [JsonProperty("userId", Required = Required.Always)]
    public int UserId { get; set; }

    [JsonProperty("artist")]
    public JsonPatchDocument<UpdateArtistDto> ArtistDto { get; set; }

    public PatchArtistRequest(int userId, JsonPatchDocument<UpdateArtistDto> artist) =>
                             (UserId, ArtistDto) = (userId, artist);

}