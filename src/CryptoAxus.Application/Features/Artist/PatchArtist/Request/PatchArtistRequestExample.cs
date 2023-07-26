namespace CryptoAxus.Application.Features.Artist.PatchArtist.Request;

public class PatchArtistRequestExample : IExamplesProvider<PatchArtistRequest>
{
    public PatchArtistRequest GetExamples()
    {
        JsonPatchDocument<UpdateArtistDto> patchDocument = new JsonPatchDocument<UpdateArtistDto>();
        patchDocument.Operations.Add(new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/userWalletAddress",
            value = "test.userWalletAddress"
        });

        patchDocument.Operations.Add(new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/profileImage",
            value = "profileImage.png"
        });

        patchDocument.Operations.Add(new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/coverImage",
            value = "coverImage.png"
        });

        patchDocument.Operations.Add(new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/website",
            value = "www.google.com"
        });

        patchDocument.Operations.Add(new Operation<UpdateArtistDto>
        {
            op = "replace",
            path = "/email",
            value = "tom@gmail.com"
        });

        return new PatchArtistRequest(null, patchDocument);
    }
}