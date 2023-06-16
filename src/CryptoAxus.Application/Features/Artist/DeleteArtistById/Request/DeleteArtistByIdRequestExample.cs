using Swashbuckle.AspNetCore.Filters;

namespace CryptoAxus.Application.Features.DeleteArtistById.Request;

public class DeleteArtistByIdRequestExample : IExamplesProvider<DeleteArtistByIdRequest>
{
    public DeleteArtistByIdRequest GetExamples()
    {
        return new DeleteArtistByIdRequest();
    }
}