namespace CryptoAxus.API.Controllers;

[ApiVersion("1.0")]
[Produces(contentType: Constants.ContentTypeJson, Constants.ContentTypeJsonHateoas,
          Constants.ContentTypeXmlHateoas,
          Constants.ContentTypeXml,
          Constants.ContentTypeTextPlain,
          Constants.ContentTypeTextJson)]
public class ArtistController : BaseController<ArtistController>
{
    public ArtistController(IMediator mediator, ILogger<ArtistController> logger) : base(mediator, logger)
    {
    }

    /// <summary>
    /// Returns artist by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="fields" example="username, email, bio"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <response code="200">Artist record retrieved</response>
    /// <returns></returns>
    [HttpGet(template: "{id:required}", Name = "GetArtistById", Order = 1)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "fields", Required = false, Source = OpenApiParameterLocation.Query, Type = typeof(string))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [ProducesResponseType(typeof(BaseResponse<ArtistDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetArtistById([FromRoute] string id,
                                                   [FromQuery] string? fields,
                                                   [FromHeader(Name = "Accept")] string mediaType)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BaseResponse<ExpandoObject>(HttpStatusCode.BadRequest,
                                                            Messages.BadRequest,
                                                             new List<string> { Messages.InvalidMediaType }));

        var response = await Mediator.Send(new GetArtistByIdRequest(id));

        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            return NotFound(response);

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
            response.Links = CreateArtistLinks(response.Result, string.Empty);

        BaseResponse<ExpandoObject> shapedResponse = new BaseResponse<ExpandoObject>(response.StatusCode,
                                                                                     response.Message,
                                                                                     response.Result?.ShapeData(fields ?? string.Empty))
        { Links = response.Links };

        return Ok(shapedResponse);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userWalletAddress"></param>
    /// <param name="artistDto"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPatch("{userWalletAddress:required}/username", Name = "PatchArtistUsername")]
    [SwaggerRequestExample(typeof(PatchArtistUsernameRequest), typeof(PatchArtistUsernameRequestExample))]
    [ProducesResponseType(typeof(PatchArtistUsernameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundPatchArtistUsernameResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestPatchArtistUsernameResponse), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> PatchArtistUsername([FromRoute] string userWalletAddress,
                                                         [FromBody] JsonPatchDocument<ArtistDto> artistDto)
    {
        var response = await Mediator.Send(new PatchArtistUsernameRequest(userWalletAddress, artistDto));

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.NoContent => Ok(response),
            _ => BadRequest(response)
        };
    }

    #region Links Helper Region

    private IReadOnlyList<Links> CreateArtistLinks(ArtistDto dto, string? fields)
    {
        Links link;
        List<Links> links = new List<Links>();
        if (!string.IsNullOrWhiteSpace(fields))
        {
            link = new Links(Url.RouteUrl("GetArtistById", new { dto.Id, fields }), "self", "GET");
            link.Href = link.Href?.Replace("/api", $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}/api");
            links.Add(link);
        }
        else
        {
            link = new Links(Url.RouteUrl("GetArtistById", new { dto.Id }), "self", "GET");
            link.Href = link.Href?.Replace("/api", $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}/api");
            links.Add(link);
        }

        link = new Links(Url.RouteUrl("PatchArtistUsername", new { dto.UserWalletAddress }), "patch_username", "PATCH");
        link.Href = link.Href?.Replace("/api", $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}/api");
        links.Add(link);

        return links.AsReadOnly();
    }

    #endregion
}