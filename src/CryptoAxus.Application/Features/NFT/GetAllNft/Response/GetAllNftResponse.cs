namespace CryptoAxus.Application.Features.NFT.GetAllNft.Response;

public class GetAllNftResponse : PaginationResponse<List<NftDto>>
{
    public GetAllNftResponse() { }

    public GetAllNftResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }

    public GetAllNftResponse(HttpStatusCode statusCode,
                             string? message,
                             List<NftDto> result,
                             PaginationData paginationData)
                           : this(statusCode, message) => (Result, PaginationData) = (result, paginationData);
}