namespace Acerola.Application
{
    public interface IResponseConverter
    {
        T Map<T>(object source);
    }
}
