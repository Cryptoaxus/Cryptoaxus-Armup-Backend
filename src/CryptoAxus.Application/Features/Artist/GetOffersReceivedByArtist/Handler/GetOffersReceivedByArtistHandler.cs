namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Handler;

public class GetOffersReceivedByArtistHandler : BaseHandler<GetOffersReceivedByArtistHandler>,
                                                IRequestHandler<GetOffersReceivedByArtistRequest, GetOffersReceivedByArtistResponse>
{
    private readonly IRepository<OffersDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetOffersReceivedByArtistHandler(IRepository<OffersDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetOffersReceivedByArtistResponse> Handle(GetOffersReceivedByArtistRequest request,
                                                                CancellationToken cancellationToken = default)
    {
        GetOffersReceivedByArtistResponse? response =
                await _cacheService.GetAsync<GetOffersReceivedByArtistResponse>(
                key: $"offersReceivedByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.OfferFrom.Equals(request.UserId), cancellationToken);

        var offersTask = _repository.FilterBy(x => x.OfferTo.Equals(request.UserId),
                                                                              request.PaginationParameters.PageNumber,
                                                                              request.PaginationParameters.PageSize,
                                                                              cancellationToken);

        await Task.WhenAll(countTask, offersTask);

        if (!offersTask.Result.Any())
            return new GetOffersReceivedByArtistResponse(HttpStatusCode.NotFound, $"No records found against userId: {request.UserId}");

        PaginationData paginationData = new PaginationData(countTask.Result,
                                                           request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);

        response = new GetOffersReceivedByArtistResponse(HttpStatusCode.OK, "Records found successfully.",
                                                         offersTask.Result.Adapt<List<OffersDtoWithLinks>>(),
                                                         paginationData);

        await _cacheService.SetAsync(key: $"offersReceivedByArtistP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                                     value: JsonSerializer.Serialize(response));

        return response;
    }
}