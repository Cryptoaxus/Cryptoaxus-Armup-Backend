namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Request;

public class PatchArtistUsernameRequestExample : IExamplesProvider<PatchArtistUsernameRequest>
{
    public PatchArtistUsernameRequest GetExamples()
    {
        JsonPatchDocument<ArtistDto> patchDocument = new JsonPatchDocument<ArtistDto>();
        patchDocument.Operations.Add(new Operation<ArtistDto>
        {
            op = "replace",
            path = "/username",
            value = "test.username"
        });

        return new PatchArtistUsernameRequest(string.Empty, patchDocument);
    }
}