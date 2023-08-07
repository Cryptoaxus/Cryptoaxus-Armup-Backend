namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Request;

public class GetNftCollectionsByCategoryRequest : IRequest<GetNftCollectionsByCategoryResponse>
{
    internal string Category { get; set; }

    internal PaginationParameters PaginationParameters { get; set; }

    public GetNftCollectionsByCategoryRequest(string category, PaginationParameters paginationParameters)
        => (Category, PaginationParameters) = (category, paginationParameters);
}