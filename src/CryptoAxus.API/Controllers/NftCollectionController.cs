namespace CryptoAxus.API.Controllers;

[ApiVersion("1.0")]
[Produces(contentType: Constants.ContentTypeJson, Constants.ContentTypeJsonHateoas,
             Constants.ContentTypeXmlHateoas,
             Constants.ContentTypeXml,
             Constants.ContentTypeTextPlain,
             Constants.ContentTypeTextJson)]
public class NftCollectionController : BaseController<NftCollectionController>
{
    public NftCollectionController(IMediator mediator, ILogger<NftCollectionController> logger) : base(mediator, logger)
    {
    }

    [HttpPost(Name = "PostNftCollection")]
    [RequiresParameter(Name = "dto", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(CreateNftCollectionsDto))]
    [SwaggerRequestExample(typeof(PostNftCollectionRequest), typeof(PostNftCollectionRequestExample))]
    [ProducesResponseType(typeof(PostNftCollectionResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ConflictPostNftCollectionResponse), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> PostNftCollection([FromBody] CreateNftCollectionsDto dto,
                                                       CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new PostNftCollectionRequest(dto), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.Conflict))
            return Conflict(response);

        return CreatedAtRoute("PostNftCollection", new { id = response.Result?.Id }, response);
    }
}