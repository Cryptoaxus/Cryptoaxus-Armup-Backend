namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Handler;

public class GetArtistByUserIdHandler : BaseHandler<GetArtistByUserIdHandler>,
                                               IRequestHandler<GetArtistByUserIdRequest, GetArtistByUserIdResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public GetArtistByUserIdHandler(IRepository<ArtistDocument> repository, ILogger<GetArtistByUserIdHandler> logger) : base(logger)
    {
        _repository = repository;
    }

    public async Task<GetArtistByUserIdResponse> Handle(GetArtistByUserIdRequest request,
                                                               CancellationToken cancellationToken = default)
    {
        ArtistDocument artist = await _repository.FindOneAsync(x => x.UserId.Equals(request.UserId), cancellationToken);

        if (artist is null)
            return new GetArtistByUserIdResponse(HttpStatusCode.NotFound,
                                                        message: $"No artist found against userId: {request.UserId}");

        ArtistDto artistDto = artist.Adapt<ArtistDto>();

        return new GetArtistByUserIdResponse(HttpStatusCode.OK,
                                                    message: "Artist record found successfully",
                                                    result: artistDto);
    }
}