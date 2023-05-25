namespace CryptoAxus.Common.Interfaces;

public interface IMapper
{
    //void Map<TSource, TDestination>(in TSource source, out TDestination destination) where TDestination : class;

    TDestination Map<TSource, TDestination>(in TSource source, out TDestination destination);
}