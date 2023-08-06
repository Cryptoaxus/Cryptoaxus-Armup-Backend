namespace CryptoAxus.Application.Features.NftCollection.GetNftCollections.Handler;

public class GetNftCollectionsHandler : BaseHandler<GetNftCollectionsHandler>,
                                        IRequestHandler<GetNftCollectionsRequest, GetNftCollectionsResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetNftCollectionsHandler(IRepository<NftCollectionsDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetNftCollectionsResponse> Handle(GetNftCollectionsRequest request,
                                                        CancellationToken cancellationToken)
    {
        GetNftCollectionsResponse? response = await _cacheService.GetAsync<GetNftCollectionsResponse>(
         key: $"allNftCollectionsP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.IsDeleted.Equals(false), cancellationToken);

        var nftCollectionTask = _repository.FilterByAsync(x => x.IsDeleted.Equals(false),
                                                          request.PaginationParameters.PageNumber,
                                                          request.PaginationParameters.PageSize,
                                                          cancellationToken);

        await Task.WhenAll(countTask, nftCollectionTask);

        if (nftCollectionTask.Result.Count.Equals(0))
            return new NotFoundGetNftCollectionsResponse();

        PaginationData paginationData = new PaginationData(countTask.Result,
                                                           request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);

        response = new GetNftCollectionsResponse(nftCollectionTask.Result.Adapt<List<NftCollectionsDto>>(),
                                                 paginationData);

        _cacheService.SetAsync(key: $"allNftCollectionP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                               value: JsonSerializer.Serialize(response));

        return response;
    }
}