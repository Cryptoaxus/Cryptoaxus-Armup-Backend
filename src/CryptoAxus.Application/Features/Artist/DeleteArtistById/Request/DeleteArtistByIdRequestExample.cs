namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Request;

public class DeleteArtistByIdRequestExample : IExamplesProvider<DeleteArtistByIdRequest>
{
    public DeleteArtistByIdRequest GetExamples()
    {
        return new DeleteArtistByIdRequest("647115d2b38bc8ea242beb01");
    }
}