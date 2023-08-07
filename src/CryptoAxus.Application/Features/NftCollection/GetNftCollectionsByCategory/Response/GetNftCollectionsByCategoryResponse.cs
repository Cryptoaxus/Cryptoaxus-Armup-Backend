namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Response;

public class GetNftCollectionsByCategoryResponse : PaginationResponse<List<NftCollectionsDto>>
{
    public GetNftCollectionsByCategoryResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetNftCollectionsByCategoryResponse(List<NftCollectionsDto> result, PaginationData paginationData) : base(HttpStatusCode.OK,
     "Records retrieved successfully.") => (Result, PaginationData) = (result, paginationData);
}