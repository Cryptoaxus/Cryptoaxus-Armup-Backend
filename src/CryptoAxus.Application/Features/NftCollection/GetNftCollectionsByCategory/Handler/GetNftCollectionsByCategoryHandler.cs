namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Handler;

public class GetNftCollectionsByCategoryHandler : BaseHandler<GetNftCollectionsByCategoryHandler>,
                                                  IRequestHandler<GetNftCollectionsByCategoryRequest, GetNftCollectionsByCategoryResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetNftCollectionsByCategoryHandler(IRepository<NftCollectionsDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetNftCollectionsByCategoryResponse> Handle(GetNftCollectionsByCategoryRequest request,
                                                                  CancellationToken cancellationToken)
    {
        GetNftCollectionsByCategoryResponse? response = await _cacheService.GetAsync<GetNftCollectionsByCategoryResponse>(
         $"allNftByCategoryP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.Category.Equals(request.Category), cancellationToken);

        var nftCollectionsTask = _repository.FilterByAsync(x
                                                                   => x.Category.Equals(request.Category),
                                                                      request.PaginationParameters.PageNumber,
                                                                      request.PaginationParameters.PageSize,
                                                                      cancellationToken);

        await Task.WhenAll(countTask, nftCollectionsTask);

        if (nftCollectionsTask.Result.Count.Equals(0))
            return new NotFoundGetNftCollectionsByCategoryResponse(request.Category);

        PaginationData paginationData = new PaginationData(countTask.Result, request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);

        response = new GetNftCollectionsByCategoryResponse(nftCollectionsTask.Result.Adapt<List<NftCollectionsDto>>(),
                                                           paginationData);

        await _cacheService.SetAsync($"allNftByCategoryP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                                     JsonSerializer.Serialize(response));

        return response;
    }
}