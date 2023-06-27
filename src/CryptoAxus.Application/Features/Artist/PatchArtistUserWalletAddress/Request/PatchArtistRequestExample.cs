namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Request;

public class PatchArtistRequestExample : IExamplesProvider<PatchArtistRequest>
{
    public PatchArtistRequest GetExamples()
    {
        {
            JsonPatchDocument<UpdateArtistDto> patchDocument = new JsonPatchDocument<UpdateArtistDto>();
            patchDocument.Operations.Add(new Operation<UpdateArtistDto>
            {
                op = "replace",
                path = "/userWalletAddress",
                value = "test.userWalletAddress"
            });
            return new PatchArtistRequest("0x51c330436F289192F43666e51Df72Ec06F66Dad9", patchDocument);
        }
    }
}