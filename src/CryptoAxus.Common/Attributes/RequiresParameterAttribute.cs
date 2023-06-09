namespace CryptoAxus.Common.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class RequiresParameterAttribute : Attribute
{
    public string Name { get; set; }

    public OpenApiParameterLocation Source { get; set; }

    public Type Type { get; set; }

    public bool Required { get; set; }
}