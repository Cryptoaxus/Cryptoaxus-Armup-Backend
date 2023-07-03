namespace CryptoAxus.Application.Features.Artist.PatchArtist.Request;

public class PatchArtistRequest : IRequest<PatchArtistResponse>
{
    [JsonProperty("userWalletAddress", Required = Required.Always)]
    public string UserWalletAddress { get; set; }

    [JsonProperty("artist")]

    public JsonPatchDocument<UpdateArtistDto> ArtistDto { get; set; }

    public PatchArtistRequest(string userWalletAddress, JsonPatchDocument<UpdateArtistDto> artist) => 
                             (UserWalletAddress, ArtistDto) = (userWalletAddress, artist);

}