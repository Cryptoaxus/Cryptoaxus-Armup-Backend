namespace CryptoAxus.Common.Helpers;

public static class LinksHelper
{
    public static IReadOnlyList<Links> CreateLinks(object id, string? fields, IHttpContextAccessor httpContextAccessor)
    {
        List<Links> links = new List<Links>();
        UriBuilder uriBuilder = new UriBuilder
        {
            Scheme = httpContextAccessor.HttpContext.Request.Scheme,
            Host = httpContextAccessor.HttpContext.Request.Host.ToString(),
            Path = httpContextAccessor.HttpContext.Request.Path.ToString(),
            Query = httpContextAccessor.HttpContext.Request.QueryString.ToString(),
        };

        if (!string.IsNullOrWhiteSpace(value: fields))
        {
            links.Add(new Links(href: uriBuilder.Uri.AbsoluteUri, rel: "self", method: "GET"));
        }
        else
        {
            links.Add(new Links(href: uriBuilder.Uri.AbsoluteUri, rel: "self", method: "GET"));
        }

        IReadOnlyList<Links> readOnlyList = links;

        return readOnlyList;
    }
}