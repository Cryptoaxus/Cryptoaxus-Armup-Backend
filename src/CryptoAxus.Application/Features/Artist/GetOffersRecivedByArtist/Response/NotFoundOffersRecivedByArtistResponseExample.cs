namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Response;

    public class NotFoundOffersRecivedByArtistResponseExample : IExamplesProvider<NotFoundGetOffersRecivedByArtistResponse>
    {
        public NotFoundGetOffersRecivedByArtistResponse GetExamples()
        {
            return new NotFoundGetOffersRecivedByArtistResponse
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