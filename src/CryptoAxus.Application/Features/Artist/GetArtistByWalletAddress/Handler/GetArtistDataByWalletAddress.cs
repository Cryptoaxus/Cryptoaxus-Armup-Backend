using CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Request;
using CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Handler;

public class GetArtistByWalletAddressHandler : BaseHandler<GetArtistByWalletAddressHandler>, IRequestHandler<GetArtistByWalletAddressRequest, GetArtistByWalletAddressResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public GetArtistByWalletAddressHandler(IRepository<ArtistDocument> repository, ILogger<GetArtistByWalletAddressHandler> logger) : base(logger)
    {
        _repository = repository;
    }

    public async Task<GetArtistByWalletAddressResponse> Handle(GetArtistByWalletAddressRequest request,
                                                      CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        ArtistDocument artist = await _repository.FindOneAsync(x => x.UserWalletAddress.Equals(request.UserWalletAddress));

        if (artist is null)
            return new GetArtistByWalletAddressResponse(HttpStatusCode.NotFound,
                                             message: $"No artist found against WalletAddress: {request.UserWalletAddress}",
                                             result: null);

        ArtistDto artistDto = artist.Adapt<ArtistDto>();

        return new GetArtistByWalletAddressResponse(HttpStatusCode.OK,
                                         message: "Artist record found successfully",
                                         result: artistDto);
    }
}