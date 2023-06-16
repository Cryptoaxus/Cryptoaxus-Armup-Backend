﻿using Swashbuckle.AspNetCore.Filters;

namespace CryptoAxus.Application.Features.DeleteArtistById.Response;

public class DeleteArtistByIdResponseExample : IExamplesProvider<DeleteArtistByIdResponse>
{
    public DeleteArtistByIdResponse GetExamples()
    {
        return new DeleteArtistByIdResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Record deleted successfully",
            Result = null,
            StatusCode = HttpStatusCode.NoContent
        };
    }
}