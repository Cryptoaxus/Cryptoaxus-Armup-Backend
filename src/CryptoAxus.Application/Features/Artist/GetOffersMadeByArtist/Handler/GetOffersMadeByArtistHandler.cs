namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Handler;

public class GetOffersMadeByArtistHandler : BaseHandler<GetOffersMadeByArtistHandler>,
                                            IRequestHandler<GetOffersMadeByArtistRequest, GetOffersMadeByArtistResponse>
{
    private readonly IRepository<OffersDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetOffersMadeByArtistHandler(IRepository<OffersDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetOffersMadeByArtistResponse> Handle(GetOffersMadeByArtistRequest request,
                                                            CancellationToken cancellationToken = default)
    {
        GetOffersMadeByArtistResponse? response =
                await _cacheService.GetAsync<GetOffersMadeByArtistResponse>(
                key: $"offersMadeByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.OfferFrom.Equals(request.UserId), cancellationToken);

        var offersTask = _repository.FilterBy(offer => offer.OfferFrom.Equals(request.UserId),
                                              request.PaginationParameters.PageNumber,
                                              request.PaginationParameters.PageSize,
                                              cancellationToken);

        await Task.WhenAll(countTask, offersTask);

        if (!offersTask.Result.Any())
            return new GetOffersMadeByArtistResponse(HttpStatusCode.NotFound,
                                                     $"No records found against userId: {request.UserId}.");

        PaginationData paginationData = new PaginationData(countTask.Result,
                                                           request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);

        response = new GetOffersMadeByArtistResponse(HttpStatusCode.OK, "Records found successfully.",
                                                     offersTask.Result.Adapt<List<OffersDtoWithLinks>>(),
                                                     paginationData);

        await _cacheService.SetAsync(key: $"offersMadeByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                                     value: JsonSerializer.Serialize(response));

        return response;
    }
}