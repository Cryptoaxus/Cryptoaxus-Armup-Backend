using CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Request;
using CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Response;
using CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Request;
using CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Response;
using CryptoAxus.Application.Features.NftCollection.GetNftCollections.Request;
using CryptoAxus.Application.Features.NftCollection.GetNftCollections.Response;
using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Request;
using CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Response;

namespace CryptoAxus.API.Controllers;

[ApiVersion("1.0")]
[Produces(Constants.ContentTypeJson, Constants.ContentTypeJsonHateoas,
          Constants.ContentTypeTextPlain,
          Constants.ContentTypeTextJson)]
public class NftCollectionController : BaseController<NftCollectionController>
{
    public NftCollectionController(IMediator mediator, ILogger<NftCollectionController> logger) : base(mediator, logger)
    {
    }

    /// <summary>
    /// Returns the nft collection record via id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <param name="fields" example="id, createdBy"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "GetNftCollectionById", Order = 1)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "fields", Required = false, Source = OpenApiParameterLocation.Query, Type = typeof(string))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [ProducesResponseType(typeof(GetNftCollectionByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetNftCollectionByIdResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetNftCollectionByIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetNftCollectionById([FromRoute] string id,
                                                          [FromHeader] string mediaType,
                                                          [FromQuery] string fields,
                                                          CancellationToken cancellationToken = default)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BadRequestGetNftCollectionByIdResponse());

        var response = await Mediator.Send(new GetNftCollectionByIdRequest(id), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(response);

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
            response.Links = CreateNftCollectionLinks(id, fields);

        return Ok(response);
    }

    /// <summary>
    /// Returns paged response of nft collections
    /// </summary>
    /// <param name="paginationParameters"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet(Name = "GetNftCollections", Order = 2)]
    [RequiresParameter(Name = "paginationParameters", Required = true, Source = OpenApiParameterLocation.Query, Type = typeof(PaginationParameters))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [ProducesResponseType(typeof(GetNftCollectionsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetNftCollectionsResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetNftCollectionsResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetNftCollections([FromQuery] PaginationParameters paginationParameters,
                                                       [FromHeader] string mediaType,
                                                       CancellationToken cancellationToken = default)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BadRequestGetNftCollectionsResponse());

        var response = await Mediator.Send(new GetNftCollectionsRequest(paginationParameters), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(response);

        if (!string.IsNullOrEmpty(paginationParameters.Fields))
            return Ok(new PaginationResponse<List<ExpandoObject>>(response.StatusCode,
                                                                  response.Message,
                                                                  response.Result?.ShapeData(paginationParameters.Fields),
                                                                  response.PaginationData));

        return Ok(response);
    }

    /// <summary>
    /// Returns the list of nft collections by wallet address
    /// </summary>
    /// <param name="walletAddress" example="0x5071ace58s9d2s8e2"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <param name="fields" example="id, createdBy"></param>
    /// <param name="cancellationToken" example="default"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{walletAddress:required}/walletAddress", Name = "GetNftCollectionsByWalletAddress", Order = 3)]
    [RequiresParameter(Name = "walletAddress", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [RequiresParameter(Name = "fields", Required = true, Source = OpenApiParameterLocation.Query, Type = typeof(string))]
    [ProducesResponseType(typeof(GetNftCollectionsByWalletAddressResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetNftCollectionsByWalletAddressResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetNftCollectionsByWalletAddressResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetNftCollectionsByWalletAddress([FromRoute] string walletAddress,
                                                                      [FromHeader] string mediaType,
                                                                      [FromQuery] string? fields = null,
                                                                      CancellationToken cancellationToken = default)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BadRequestGetNftCollectionsByWalletAddressResponse());

        var response = await Mediator.Send(new GetNftCollectionsByWalletAddressRequest(walletAddress), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(response);

        if (!string.IsNullOrEmpty(fields))
            return Ok(new BaseResponse<List<ExpandoObject>>(response.StatusCode,
                                                            response.Message,
                                                            response.Result?.ShapeData(fields)));

        return Ok(response);
    }

    /// <summary>
    /// Returns the nft collection record via id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "DeleteNftCollectionById", Order = 4)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [ProducesResponseType(typeof(DeleteNftCollectionByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundDeleteNftCollectionByIdResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestDeleteNftCollectionByIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteNftCollectionById([FromRoute] string id,
                                                             CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new DeleteNftCollectionByIdRequest(id), cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.NoContent => Ok(response),
            HttpStatusCode.NotFound => NotFound(),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Adds new nft collection in system
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="201">Created response with 201 code and information message about created record</response>
    /// <response code="409">Conflict response with 409 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
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

        return CreatedAtRoute("GetNftCollectionById", new { id = response.Result?.Id }, response);
    }

    private IReadOnlyList<Links> CreateNftCollectionLinks(string id, string? fields = null)
    {
        Links link;
        List<Links> links = new List<Links>();
        if (!string.IsNullOrWhiteSpace(fields))
        {
            link = new Links(Url.RouteUrl("GetNftCollectionById", new { id, fields }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue, $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }
        else
        {
            link = new Links(Url.RouteUrl("GetNftCollectionById", new { id }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue, $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }

        link = new Links(href: Url.RouteUrl("GetNftCollections"),
                         "get_nftCollections",
                         Constants.GetMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue, $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(Url.RouteUrl("DeleteNftCollectionById", new { id }),
                         "delete",
                         Constants.DeleteMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue, $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
        links.Add(link);

        return links.AsReadOnly();
    }
}