namespace CryptoAxus.Application.Features.NFT.GetAllNft.Handler;

public class GetAllNftHandler : BaseHandler<GetAllNftHandler>, IRequestHandler<GetAllNftRequest, GetAllNftResponse>
{
    private readonly IRepository<NftDocument> _repository;
    private readonly ICacheService _cacheService;

    public GetAllNftHandler(IRepository<NftDocument> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<GetAllNftResponse> Handle(GetAllNftRequest request, CancellationToken cancellationToken = default)
    {
        GetAllNftResponse? response =
                await _cacheService.GetAsync<GetAllNftResponse>(
                key: $"allNftP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}");

        if (response is not null)
            return response;

        var countTask = _repository.CountAsync(x => x.IsDeleted.Equals(false), cancellationToken);

        var nftTask = _repository.FilterBy(x => x.IsDeleted.Equals(false),
                                           request.PaginationParameters.PageNumber,
                                           request.PaginationParameters.PageSize,
                                           cancellationToken);

        await Task.WhenAll(countTask, nftTask);

        if (nftTask.Result.Count == 0)
            return new GetAllNftResponse(HttpStatusCode.NotFound, "No nft record exists in the system.");

        PaginationData paginationData = new PaginationData(countTask.Result,
                                                           request.PaginationParameters.PageNumber,
                                                           request.PaginationParameters.PageSize);


        response = new GetAllNftResponse(HttpStatusCode.OK,
                                         "Records retrieved successfully.",
                                         nftTask.Result.Adapt<List<NftDto>>(),
                                         paginationData);

        _cacheService.SetAsync(key: $"allNftP{request.PaginationParameters.PageNumber}S{request.PaginationParameters.PageSize}",
                               value: JsonSerializer.Serialize(response));

        return response;
    }
}