namespace CryptoAxus.Application.Features.Artist.Handlers;

public class GetAllArtistQueryHandler : BaseHandler<GetAllArtistQueryHandler>,
                                        IRequestHandler<GetAllArtistQuery, BaseResponse<IEnumerable<ArtistDto>>>
{
    private readonly IRepository<ArtistDocument> _repository;

    public GetAllArtistQueryHandler(IRepository<ArtistDocument> repository,
                                    ILogger<GetAllArtistQueryHandler> logger) : base(logger)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<IEnumerable<ArtistDto>>> Handle(GetAllArtistQuery request,
                                                                   CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            IEnumerable<ArtistDocument> result = _repository.AsQueryable();

            if (!result.Any())
                return new BaseResponse<IEnumerable<ArtistDto>>(HttpStatusCode.OK, "Unable to retrieve records");

            return new BaseResponse<IEnumerable<ArtistDto>>(HttpStatusCode.OK,
                                                            message: "Records retrieved successfully",
                                                            result: result.Adapt<IEnumerable<ArtistDto>>());
        }, cancellationToken);
    }
}