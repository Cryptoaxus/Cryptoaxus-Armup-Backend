using Swashbuckle.AspNetCore.Filters;

namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class BadRequestPatchArtistUsernameResponseExample : IExamplesProvider<BadRequestPatchArtistUsernameResponse>
{
    public BadRequestPatchArtistUsernameResponse GetExamples()
    {
        return new BadRequestPatchArtistUsernameResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Bad request unable to update username",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}