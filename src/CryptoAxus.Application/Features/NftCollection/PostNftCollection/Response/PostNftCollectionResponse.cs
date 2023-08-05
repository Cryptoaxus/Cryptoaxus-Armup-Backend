namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;

public class PostNftCollectionResponse : BaseResponse<NftCollectionsDto>
{
    public PostNftCollectionResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public PostNftCollectionResponse(NftCollectionsDto dto) : this(HttpStatusCode.Created, "Nft collection created successfully.")
        => Result = dto;
}