using CryptoAxus.Application.Features.NFT.PutNft.Request;
using CryptoAxus.Application.Features.NFT.PutNft.Response;

namespace CryptoAxus.API.Controllers;

[ApiVersion("1.0")]
[Produces(contentType: Constants.ContentTypeJson, Constants.ContentTypeJsonHateoas,
             Constants.ContentTypeTextPlain,
             Constants.ContentTypeTextJson)]
public class NftController : BaseController<NftController>
{
    public NftController(IMediator mediator, ILogger<NftController> logger) : base(mediator, logger)
    {
    }

    /// <summary>
    /// Returns the nft searched by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="fields" example="id, name, url"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "GetNftById", Order = 1)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "fields", Required = false, Source = OpenApiParameterLocation.Query, Type = typeof(string))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    //[SwaggerRequestExample(typeof(GetNftByIdRequest), typeof(GetNftByIdRequestExample))]
    [ProducesResponseType(typeof(GetNftByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetNftByIdResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetNftByIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetNftById([FromRoute] string id,
                                                [FromQuery] string? fields,
                                                [FromHeader(Name = "Accept")] string mediaType)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BaseResponse<ExpandoObject>(HttpStatusCode.BadRequest,
                                                              Messages.BadRequest,
                                                              new List<string> { Messages.InvalidMediaType }));

        var response = await Mediator.Send(new GetNftByIdRequest(id));

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(response);

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
            response.Links = CreateNftLinks(id: id, fields: fields);

        BaseResponse<ExpandoObject> shapedResponse = new BaseResponse<ExpandoObject>(response.StatusCode,
                                                                                     response.Message,
                                                                                     response.Result?.ShapeData(fields ?? string.Empty))
        { Links = response.Links };

        return Ok(shapedResponse);
    }

    /// <summary>
    /// Returns the list of nft with pagination data
    /// </summary>
    /// <param name="paginationParameters"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet(Name = "GetAllNft", Order = 2)]
    [RequiresParameter(Name = "paginationParameters", Required = true, Source = OpenApiParameterLocation.Query, Type = typeof(PaginationParameters))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [ProducesResponseType(typeof(GetAllNftResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetAllNftResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetAllNftResponse), (int)HttpStatusCode.BadRequest)]
    [ResponseCache(CacheProfileName = "300SecondsCacheProfile")]
    public async Task<IActionResult> GetAllNft([FromQuery] PaginationParameters paginationParameters,
                                               [FromHeader(Name = "Accept")] string mediaType,
                                               CancellationToken cancellationToken = default)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BadRequestGetAllNftResponse());

        var response = await Mediator.Send(new GetAllNftRequest(paginationParameters), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(new NotFoundGetAllNftResponse());

        PaginationResponse<List<ExpandoObject>> shapedResponse =
                new PaginationResponse<List<ExpandoObject>>(response.StatusCode,
                                                            response.Message,
                                                            response.Result?.ShapeData(paginationParameters.Fields ?? string.Empty),
                                                            response.PaginationData);

        return Ok(shapedResponse);
    }

    /// <summary>
    /// Creates new nft in the system
    /// </summary>
    /// <param name="nft"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message</response>
    /// <response code="409">Conflict response with 409 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPost(Name = "CreateNft", Order = 3)]
    [RequiresParameter(Name = "nft", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(CreateNftDto))]
    [ProducesResponseType(typeof(PostNftResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ConflictPostNftResponse), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(BadRequestPostNftResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> PostNft([FromBody] CreateNftDto nft,
                                             CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new PostNftRequest(nft), cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.Conflict => Conflict(response),
            HttpStatusCode.Created => CreatedAtRoute("GetOfferById", new { id = response.Result?.Id }, response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Deletes Nft by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message about delete</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpDelete("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "DeleteNftById", Order = 4)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [ProducesResponseType(typeof(DeleteNftByIdResponse), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(NotFoundDeleteNftByIdResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestDeleteNftByIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteNftById([FromRoute] string id, CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new DeleteNftByIdRequest(id), cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.NoContent => Ok(response),
            HttpStatusCode.NotFound => NotFound(response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Updates Nft by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPut("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "PutNftById", Order = 5)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "dto", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(UpdateNftDto))]
    [SwaggerRequestExample(typeof(PutNftRequest), typeof(PutNftRequestExample))]
    //[SwaggerRequestExample(typeof(PutNftRequest), typeof(PutNftRequestExample))]
    [ProducesResponseType(typeof(PutNftResponse), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(NotFoundPutNftResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestPutNftResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> PutNftById([FromRoute] string id,
                                                [FromBody] UpdateNftDto dto,
                                                CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new PutNftRequest(id, dto), cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.NoContent => Ok(response),
            HttpStatusCode.NotFound => NotFound(response),
            _ => BadRequest(response)
        };
    }

    #region Links Helper Region

    private IReadOnlyList<Links> CreateNftLinks(string? id = null, string fields = "")
    {
        Links link;
        List<Links> links = new List<Links>();
        if (!string.IsNullOrWhiteSpace(fields))
        {
            link = new Links(Url.RouteUrl("GetNftById", new { id, fields }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }
        else
        {
            link = new Links(Url.RouteUrl("GetNftById", new { id }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }

        link = new Links(Url.RouteUrl("PostNft"), "post_nft", Constants.PostMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{Request.Scheme}://{Request.Host}{Constants.ApiValue}");
        links.Add(link);
        return links.AsReadOnly();
    }

    #endregion
}