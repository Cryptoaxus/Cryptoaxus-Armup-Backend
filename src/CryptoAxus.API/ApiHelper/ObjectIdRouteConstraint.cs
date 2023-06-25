namespace CryptoAxus.API.ApiHelper;

public class ObjectIdRouteConstraint : IRouteConstraint
{
    private readonly string _routeValue;

    public ObjectIdRouteConstraint(string routeValue)
    {
        _routeValue = routeValue;
    }

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out object? value) && value != null)
        {
            if (value.ToObjectId() == _routeValue.ToObjectId())
            {
                return true;
            }
        }
        return false;
    }
}