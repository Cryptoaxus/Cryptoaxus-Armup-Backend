namespace CryptoAxus.Application.Features.NFT.GetAllNft.Request;

public class GetAllNftRequest : IRequest<GetAllNftResponse>
{
    internal PaginationParameters PaginationParameters { get; set; }

    public GetAllNftRequest(PaginationParameters paginationParameters) => PaginationParameters = paginationParameters;
}