namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;

public class ConflictPostNftCollectionResponseExample : IExamplesProvider<ConflictPostNftCollectionResponse>
{
    public ConflictPostNftCollectionResponse GetExamples()
    {
        return new ConflictPostNftCollectionResponse("Collection with same name already exist.");
    }
}