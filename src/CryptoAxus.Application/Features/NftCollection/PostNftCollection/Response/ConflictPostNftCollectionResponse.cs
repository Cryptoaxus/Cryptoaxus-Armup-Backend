namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;

public class ConflictPostNftCollectionResponse : PostNftCollectionResponse
{
    public ConflictPostNftCollectionResponse(string? message) : base(HttpStatusCode.Conflict, message)
    {
    }
}