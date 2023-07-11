namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Handler;

public class GetOffersRecivedByArtistHandler : BaseHandler<GetOffersRecivedByArtistHandler>, 
                                               IRequestHandler<GetOffersRecivedByArtistRequest, GetOffersRecivedByArtistResponse>
{
    private readonly IRepository<OffersDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetOffersRecivedByArtistHandler(IRepository<OffersDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetOffersRecivedByArtistResponse> Handle(GetOffersRecivedByArtistRequest request,
                                                               CancellationToken cancellationToken = default)
    {
        GetOffersRecivedByArtistResponse? response =
                await _cacheService.GetAsync<GetOffersRecivedByArtistResponse>(
                key: $"offersRecivedByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.OfferFrom.Equals(request.UserId), cancellationToken);

        var offersTask = _repository.FilterBy(x => x.OfferTo.Equals(request.UserId),
                                                                    request.PaginationParameters.PageNumber,
                                                                    request.PaginationParameters.PageSize,
                                                                    cancellationToken);

        await Task.WhenAll(countTask, offersTask);

        if (!offersTask.Result.Any())
            return new GetOffersRecivedByArtistResponse(HttpStatusCode.NotFound,
                                                        $"No records found against userId: {request.UserId}");

        PaginationData paginationData = new PaginationData(countTask.Result,
                                                           request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);

        response = new GetOffersRecivedByArtistResponse(HttpStatusCode.OK, "Records found successfully.",
                                                        offersTask.Result.Adapt<List<OffersDto>>(),
                                                        paginationData);

        await _cacheService.SetAsync(key: $"offersRecivedByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                                     value: JsonSerializer.Serialize(response));

        return response;
    }
}