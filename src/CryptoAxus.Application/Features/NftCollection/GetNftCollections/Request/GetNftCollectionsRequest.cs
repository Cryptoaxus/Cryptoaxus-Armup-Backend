namespace CryptoAxus.Application.Features.NftCollection.GetNftCollections.Request;

public class GetNftCollectionsRequest : IRequest<GetNftCollectionsResponse>
{
    internal PaginationParameters PaginationParameters { get; set; }

    public GetNftCollectionsRequest(PaginationParameters paginationParameters) => PaginationParameters = paginationParameters;
}