namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByCategory.Response;

public class NotFoundGetNftCollectionsByCategoryResponse : GetNftCollectionsByCategoryResponse
{
    public NotFoundGetNftCollectionsByCategoryResponse(string category) : base(HttpStatusCode.NotFound, $"No records found against category: {category}.")
    {
    }
}