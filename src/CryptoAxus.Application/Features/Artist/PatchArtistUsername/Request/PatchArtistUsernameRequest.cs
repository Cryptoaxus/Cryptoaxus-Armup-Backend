namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Request;

public class PatchArtistUsernameRequest : IRequest<PatchArtistUsernameResponse>
{
    [JsonProperty("userWalletAddress", Required = Required.Always)]
    public string UserWalletAddress { get; set; }

    //[JsonProperty("username", Required = Required.Always)]
    public JsonPatchDocument<ArtistDto> ArtistDto { get; set; }

    public PatchArtistUsernameRequest(string userWalletAddress, JsonPatchDocument<ArtistDto> artistDto) =>
                                     (UserWalletAddress, ArtistDto) = (userWalletAddress, artistDto);
}