namespace CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Handler;

public class GetLikeFavoriteNftByArtistHandler : BaseHandler<GetLikeFavoriteNftByArtistHandler>,
                                                 IRequestHandler<GetLikeFavoriteNftByArtistRequest, GetLikeFavoriteNftByArtistResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public GetLikeFavoriteNftByArtistHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<GetLikeFavoriteNftByArtistResponse> Handle(GetLikeFavoriteNftByArtistRequest request,
                                                                 CancellationToken cancellationToken)
    {
        var likeTask = _repository.FilterBy(filterExpression: x => x.Likes != null && x.Likes.Contains(request.UserId),
                                            pageNumber: null,
                                            pageSize: null,
                                            cancellationToken: cancellationToken);

        var favoriteTask = _repository.FilterBy(filterExpression: x => x.Favorites != null && x.Favorites.Contains(request.UserId),
                                                pageNumber: null,
                                                pageSize: null,
                                                cancellationToken: cancellationToken);

        await Task.WhenAll(likeTask, favoriteTask);

        if (likeTask.Result.Count.Equals(0) && favoriteTask.Result.Count.Equals(0))
            return new NotFoundGetLikeFavoriteNftByArtistResponse($"No likes/favorites exist against artist: {request.UserId}.");

        return new GetLikeFavoriteNftByArtistResponse(HttpStatusCode.OK,
                                                      "Records found successfully.",
                                                      new LikeFavoriteNftDto(likeTask.Result.Adapt<IEnumerable<NftDto>>(),
                                                                                    favoriteTask.Result.Adapt<IEnumerable<NftDto>>()));
    }
}