namespace WebApi.Constants
{
    public interface IAutoObjectMappingProvider
    {
        TDestination Map<TSource, TDestination>(object source);
        TDestination MaP<TSource, TDestination>(TSource source, TDestination destination);
    }
}
