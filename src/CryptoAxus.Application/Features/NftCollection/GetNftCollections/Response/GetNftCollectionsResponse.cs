namespace CryptoAxus.Application.Features.NftCollection.GetNftCollections.Response;

public class GetNftCollectionsResponse : PaginationResponse<List<NftCollectionsDto>>
{
    public GetNftCollectionsResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetNftCollectionsResponse(List<NftCollectionsDto> result, PaginationData paginationData)
            : this(HttpStatusCode.OK, "Records retrieved successfully.") => (Result, PaginationData) = (result, paginationData);
}