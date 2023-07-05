namespace CryptoAxus.API.ApiHelper;

public class StringRouteConstraint : IRouteConstraint
{
    private readonly string _routeValue;

    public StringRouteConstraint(string routeValue)
    {
        _routeValue = routeValue;
    }

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out object? value) && value != null)
        {
            if (value.ToString()!.Equals(_routeValue, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}