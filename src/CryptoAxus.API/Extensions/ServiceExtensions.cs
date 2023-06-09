﻿namespace CryptoAxus.API.Extensions;

/// <summary>
/// Custom service extensions class.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Custom media type service extension.
    /// </summary>
    /// <param name="services"></param>
    public static void AddCustomMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            var newtonsoftJsonOutputFormatter = config.OutputFormatters
                                                      .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

            if (newtonsoftJsonOutputFormatter is not null)
            {
                newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.api.hateoas+json");
            }

            var xmlOutputFormatter = config.OutputFormatters
                                           .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

            if (xmlOutputFormatter is not null)
            {
                xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.api.hateoas+xml");
            }
        });
    }
}