﻿using CryptoAxus.Application.Features.Artist.GetArtistByUserId.Request;

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
    /// Returns artist an by searched by id.
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <param name="fields" example="username, email, bio"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <response code="200">Artist record retrieved</response>
    /// <returns></returns>
    [HttpGet(template: "{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "GetArtistById", Order = 1)]
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
            response.Links = CreateArtistLinks(id: id, fields: fields);

        BaseResponse<ExpandoObject> shapedResponse = new BaseResponse<ExpandoObject>(response.StatusCode,
                                                                                     response.Message,
                                                                                     response.Result?.ShapeData(fields ?? string.Empty))
        { Links = response.Links };

        return Ok(shapedResponse);
    }

    /// <summary>
    /// Delete artist by id
    /// </summary>
    /// <param name="id" example="507f191e810c19729de860ea"></param>
    /// <response code="204">Delete Artist by Id</response>
    /// <returns></returns>
    [HttpDelete(template: "{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "DeleteArtistById", Order = 2)]
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
    [HttpPost(Name = "PostArtist", Order = 3)]
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
    /// Returns artist by user id
    /// </summary>
    /// <param name="userId" example="5071"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{userId:int:required}/userId", Name = "GetArtistByUserId", Order = 4)]
    [RequiresParameter(Name = "userId", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(int))]
    [SwaggerRequestExample(typeof(GetArtistByUserIdRequest), typeof(GetArtistByUserIdRequestExample))]
    [ProducesResponseType(typeof(GetArtistByUserIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundArtistByWalletAddressResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestArtistByUserIdResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetArtistByUserId([FromRoute] int userId, [FromHeader(Name = "Accept")] string mediaType)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BaseResponse<ExpandoObject>(HttpStatusCode.BadRequest,
                                                              Messages.BadRequest,
                                                              new List<string> { Messages.InvalidMediaType }));

        var response = await Mediator.Send(new GetArtistByUserIdRequest(userId));

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
            response.Links = CreateArtistLinks(userId: userId);

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.OK => Ok(response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Patch Artist by UserId
    /// </summary>
    /// <param name="artist"></param>
    /// <param name="userId"></param>
    /// <response code="200">Success response with 204 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpPatch("{userId:int:required}", Name = "PatchArtist", Order = 5)]
    [RequiresParameter(Name = "userId", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(int))]
    [RequiresParameter(Name = "artistDto", Required = true, Source = OpenApiParameterLocation.Body, Type = typeof(JsonPatchDocument<UpdateArtistDto>))]
    [SwaggerRequestExample(typeof(PatchArtistRequest), typeof(PatchArtistRequestExample))]
    [ProducesResponseType(typeof(PatchArtistResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundPatchArtistResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestPatchArtistResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> PatchArtist([FromRoute] int userId, [FromBody] JsonPatchDocument<UpdateArtistDto> artist)
    {
        var response = await Mediator.Send(new PatchArtistRequest(userId, artist));

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.NoContent => Ok(response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// Returns list of offers made(placed) by the artist
    /// </summary>
    /// <param name="userId" example="5071"></param>
    /// <param name="paginationParameters"></param>
    /// <param name="mediaType" example="application/json"></param>
    /// <param name="cancellationToken" example="default"></param>
    /// <response code="200">Success response with 200 code and information message about update</response>
    /// <response code="404">Not Found response with 404 code and information message</response>
    /// <response code="400">Bad Request response with 400 code and information message</response>
    /// <returns></returns>
    [HttpGet("{userId:int:required}/offersMade", Name = "OffersMadeByArtist", Order = 6)]
    [RequiresParameter(Name = "userId", Required = true, Source = OpenApiParameterLocation.Path, Type = typeof(int))]
    [RequiresParameter(Name = "paginationParameters", Required = true, Source = OpenApiParameterLocation.Query, Type = typeof(PaginationParameters))]
    [RequiresParameter(Name = "mediaType", Required = true, Source = OpenApiParameterLocation.Header, Type = typeof(string))]
    [SwaggerRequestExample(typeof(GetOffersMadeByArtistRequest), typeof(GetOffersReceivedByArtistRequestExample))]
    [ProducesResponseType(typeof(GetOffersMadeByArtistResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundGetOffersMadeByArtistResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestGetOffersMadeByArtistResponse), (int)HttpStatusCode.BadRequest)]
    [ResponseCache(CacheProfileName = "300SecondsCacheProfile")]
    public async Task<IActionResult> OffersMadeByArtist([FromRoute] int userId,
                                                        [FromQuery] PaginationParameters paginationParameters,
                                                        [BindRequired, FromHeader(Name = "Accept")] string mediaType,
                                                        CancellationToken cancellationToken = default)
    {
        if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediaType))
            return BadRequest(new BadRequestGetOffersMadeByArtistResponse(HttpStatusCode.BadRequest,
                                                                          Messages.BadRequest,
                                                                          new List<string> { Messages.InvalidMediaType }));

        var response = await Mediator.Send(new GetOffersMadeByArtistRequest(userId, paginationParameters), cancellationToken);

        if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Result is not null &&
            parsedMediaType.MediaType.Value!.Contains(Constants.VndApiHateoas))
        {
            response.Result.ForEach(item => item.Links =
                                            CreateArtistLinks(userId: userId,
                                                              id: item.Id.ToString(),
                                                              fields: paginationParameters.Fields ?? string.Empty));
        }

        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.OK => Ok(response),
            _ => BadRequest(response)
        };
    }

    #region Links Helper Region

    private IReadOnlyList<Links> CreateArtistLinks(string? id = null, int? userId = null, string fields = "")
    {
        Links link;
        List<Links> links = new List<Links>();
        if (!string.IsNullOrWhiteSpace(fields))
        {
            link = new Links(Url.RouteUrl("GetArtistById", new { id, fields }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }
        else
        {
            link = new Links(Url.RouteUrl("GetArtistById", new { id }),
                             Constants.SelfRel,
                             Constants.GetMethod);
            link.Href = link.Href?.Replace(Constants.ApiValue,
                                           $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
            links.Add(link);
        }

        link = new Links(Url.RouteUrl("PatchArtistUsername", new { userId }),
                         "patch_username",
                         Constants.PatchMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(href: Url.RouteUrl("DeleteArtistById", new { id }),
                         "delete",
                         Constants.DeleteMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(Url.RouteUrl("GetArtistByWalletAddress", new { userId }),
                         "get_userWalletAddress",
                         Constants.GetMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        link = new Links(Url.RouteUrl("PatchArtist", new { userId }),
                         "patch_artist",
                         Constants.PatchMethod);
        link.Href = link.Href?.Replace(Constants.ApiValue,
                                       $"{HttpContext?.Request.Scheme}://{HttpContext?.Request.Host}{Constants.ApiValue}");
        links.Add(link);

        return links.AsReadOnly();
    }

    #endregion
}