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
                          rel: "artist",
                          method: Constants.GetMethod),

                new Links(href: Url.RouteUrl("PatchArtistUsername", values: new { userWalletAddress = "0x51c330436F289192F43666e51Df72Ec06F66Dad9" }),
                          rel: "patch_username",
                          method: Constants.PatchMethod),

                new Links(href: Url.RouteUrl("DeleteArtistById", values: new { id = "648042e75ce6c1392e35460c" }),
                          rel: "delete_artist",
                          method: Constants.DeleteMethod),

                new Links(href: Url.RouteUrl("PostArtist"),
                          rel: "post",
                          method: Constants.PostMethod),

               new Links(href: Url.RouteUrl(routeName: "GetArtistByWalletAddress", values: new { userWalletAddress = "0x647115d2b38bc8ea242beb01" }),
                          rel: "artist",
                          method: Constants.GetMethod),
            };
            return new BaseResponse<IReadOnlyList<Links>>(statusCode: HttpStatusCode.OK, message: null, result: links.AsReadOnly());
        }));
    }
}