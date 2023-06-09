using CryptoAxus.Application.Features.Artist.GetArtistById.Query;

namespace CryptoAxus.Application.Features.Artist.GetArtistById.Handler;

public class GetArtistByIdQueryHandler : BaseHandler<GetArtistByIdQueryHandler>, IRequestHandler<GetArtistByIdQuery, BaseResponse<ArtistDto>>
{
    private readonly IRepository<ArtistDocument> _repository;

    public GetArtistByIdQueryHandler(IRepository<ArtistDocument> repository, ILogger<GetArtistByIdQueryHandler> logger) : base(logger)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<ArtistDto>> Handle(GetArtistByIdQuery request,
                                                      CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        ArtistDocument artist = await _repository.FindByIdAsync(request.Id.ToObjectId());

        if (artist is null)
            return new BaseResponse<ArtistDto>(HttpStatusCode.NotFound,
                                               message: $"No artist found against id: {request.Id}",
                                               result: null);

        ArtistDto artistDto = artist.Adapt<ArtistDto>();

        return new BaseResponse<ArtistDto>(HttpStatusCode.OK,
                                           message: "Artist record found successfully",
                                           result: artistDto);
    }
}