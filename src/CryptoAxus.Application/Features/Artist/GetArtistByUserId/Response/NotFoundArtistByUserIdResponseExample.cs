﻿namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Response;

public class NotFoundArtistByUserIdResponseExample : IExamplesProvider<NotFoundArtistByUserIdResponse>
{
    public NotFoundArtistByUserIdResponse GetExamples()
    {
        return new NotFoundArtistByUserIdResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against userWalletAddress: 507f191e810c19729de860ea",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}