using Microsoft.AspNetCore.Mvc.Formatters;

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
    /// Patch Artist
    /// </summary>
    /// <param name="userWalletAddress" example="0x507f191e810c19729de860ea"></param>
    /// <param name="artistDto"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPatch("{userWalletAddress:required}/username", Name = "PatchArtistUsername", Order = 2)]
    [RequiresParameter(Name = "userWalletAddress", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "artistDto", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(JsonPatchDocument<ArtistDto>))]
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
    /// <summary>
    /// Delete artist by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <response code="204">Delete Artist by Id</response>
    /// <returns></returns>
    [HttpDelete(template: "{id:required}", Name = "DeleteArtistById", Order = 3)]
    [RequiresParameter(Name = "id", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [ProducesResponseType(typeof(BaseResponse<ArtistDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundDeleteArtistByIdResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestDeleteArtistByIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteArtistById([FromRoute] string id)
    {
        var response = await Mediator.Send(new DeleteArtistByIdRequest(id));

        return response.StatusCode switch
        {
            HttpStatusCode.NoContent => StatusCode((int)HttpStatusCode.NoContent, response),
            HttpStatusCode.NotFound => NotFound(response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Creates a new artist in the database
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    [HttpPost(Name = "PostArtist", Order = 4)]
    [RequiresParameter(Name = "artist", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(CreateArtistDto))]
    //[SwaggerRequestExample(typeof(PostArtistRequest), typeof(PostArtistRequestExample))]
    [ProducesResponseType(typeof(PostArtistResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BadRequestPostArtistResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ConflictPostArtistResponse), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> PostArtist([FromBody] CreateArtistDto artist)
    {
        var response = await Mediator.Send(new PostArtistRequest(artist));

        if (response.StatusCode == HttpStatusCode.Conflict)
            return BadRequest(response);
        return CreatedAtRoute("GetArtistById", new { id = response.Result?.Id }, response);
    }

    /// <summary>
    /// Returns artist by Wallet Address
    /// </summary>
    /// <param name="userWalletAddress" example="0x507f191e810c19729de860ea"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{userWalletAddress:required}/userWalletAddress", Name = "GetArtistByWalletAddress", Order = 5)]
    [RequiresParameter(Name = "userWalletAddress", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [SwaggerRequestExample(typeof(GetArtistByWalletAddressRequest), typeof(GetArtistByWalletAddressRequestExample))]
    [ProducesResponseType(typeof(GetArtistByWalletAddressResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundArtistByWalletAddressResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestArtistByWalletAddressResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetArtistByWalletAddressRequest([FromRoute] string userWalletAddress, 
                                                                     [FromHeader(Name = "Accept")] string mediaType)
    {
         if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BaseResponse<ExpandoObject>(HttpStatusCode.BadRequest,
                                                              Messages.BadRequest,
                                                              new List<string> { Messages.InvalidMediaType }));

        var response = await Mediator.Send(new GetArtistByWalletAddressRequest(userWalletAddress));

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
            response.Links = CreateArtistLinks(response.Result, string.Empty);

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.OK => Ok(response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Patch Artist by UserWalletAddress
    /// </summary>
    /// <param name="artist"></param>
    /// <param name="userWalletAddress"></param>

    /// <response code="200">Success response with 204 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPatch("{userWalletAddress:required}", Name = "PatchArtist", Order = 6)]
    [RequiresParameter(Name = "userWalletAddress", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(string))]
    [RequiresParameter(Name = "artistDto", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(JsonPatchDocument<UpdateArtistDto>))]
    [SwaggerRequestExample(typeof(PatchArtistRequest), typeof(PatchArtistRequestExample))]
    [ProducesResponseType(typeof(PatchArtistResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundPatchArtistResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestPatchArtistResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> PatchArtist([FromRoute] string userWalletAddress, [FromBody]  JsonPatchDocument<UpdateArtistDto> artist)
    {
           var response = await Mediator.Send(new PatchArtistRequest(userWalletAddress, artist));

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
            link = new Links(Url.RouteUrl("GetArtistById", new { dto.Id, fields }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }
        else
        {
            link = new Links(Url.RouteUrl("GetArtistById", new { dto.Id }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }

        link = new Links(Url.RouteUrl("PatchArtistUsername", new { dto.UserWalletAddress }),
                         "patch_username",
                         Constants.PatchMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(href: Url.RouteUrl("DeleteArtistById", new { dto.Id }),
                         "delete",
                         Constants.DeleteMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(Url.RouteUrl("GetArtistByWalletAddress", new { dto.UserWalletAddress }),
                         "get_userWalletAddress",
                         Constants.GetMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(Url.RouteUrl("PatchArtist", new { dto.UserWalletAddress }),
                         "patch_artist",
                         Constants.PatchMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        return links.AsReadOnly();
    }

    #endregion
}