namespace CryptoAxus.Application.Features.Artist.GetArtistById.Handler;

public class GetArtistByIdQueryHandler : BaseHandler<GetArtistByIdQueryHandler>, IRequestHandler<GetArtistByIdRequest, GetArtistByIdResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public GetArtistByIdQueryHandler(IRepository<ArtistDocument> repository, ILogger<GetArtistByIdQueryHandler> logger) : base(logger)
    {
        _repository = repository;
    }

    public async Task<GetArtistByIdResponse> Handle(GetArtistByIdRequest request,
                                                    CancellationToken cancellationToken = default)
    {
        ArtistDocument artist = await _repository.FindByIdAsync(request.Id.ToObjectId());

        if (artist is null)
            return new GetArtistByIdResponse(HttpStatusCode.NotFound,
                                             message: $"No artist found against id: {request.Id}",
                                             result: null);

        ArtistDto artistDto = artist.Adapt<ArtistDto>();

        return new GetArtistByIdResponse(HttpStatusCode.OK,
                                         message: "Artist record found successfully",
                                         result: artistDto);
    }
}