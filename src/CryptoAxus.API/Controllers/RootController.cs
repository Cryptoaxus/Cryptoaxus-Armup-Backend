namespace CryptoAxus.API.Controllers;

[Route("api")]
[ApiController]
public class RootController : ControllerBase
{
    /// <summary>
    /// Root method to return url for all endpoints in the API.
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetRoot")]
    public async Task<ActionResult<BaseResponse<IReadOnlyList<Links>>>> GetRoot()
    {
        return Ok(await Task.Run(function: () =>
        {
            List<Links> links = new List<Links>
            {
                new Links(href: Url.RouteUrl(routeName: "GetRoot"),
                          rel: Constants.SelfRel,
                          method: Constants.GetMethod),

                new Links(href: Url.RouteUrl(routeName: "GetArtistById", values: new { id = "648042e75ce6c1392e35460c" }),
                          rel: Constants.CustomerRel,
                          method: Constants.GetMethod)
            };

            return new BaseResponse<IReadOnlyList<Links>>(statusCode: HttpStatusCode.OK, message: null, result: links.AsReadOnly());
        }));
    }
}