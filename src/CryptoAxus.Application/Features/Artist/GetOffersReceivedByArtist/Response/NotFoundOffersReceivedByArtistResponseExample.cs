namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;

    public class NotFoundOffersReceivedByArtistResponseExample : IExamplesProvider<NotFoundGetOffersReceivedByArtistResponse>
    {
        public NotFoundGetOffersReceivedByArtistResponse GetExamples()
        {
            return new NotFoundGetOffersReceivedByArtistResponse
            {
                ApiException = null,
                Errors = null,
                IsSuccessful = false,
                Links = null,
                Message = "No records found against userId: 6471",
                PaginationData = null,
                Result = null,
                StatusCode = HttpStatusCode.NotFound
            };
        }
    }