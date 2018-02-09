namespace Acerola.Application.Mappers
{
    public interface IDTOMapper
    {
        T Map<T>(object source);
    }
}
