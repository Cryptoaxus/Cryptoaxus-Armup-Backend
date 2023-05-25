namespace CryptoAxus.Common.Contracts;

public abstract class Mapper
{
    public abstract TDestination Map<TSource, TDestination>(TSource source);
}