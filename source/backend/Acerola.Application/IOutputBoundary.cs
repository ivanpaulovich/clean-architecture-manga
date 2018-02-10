namespace Acerola.Application
{
    public interface IOutputBoundary<T>
    {
        void Populate(T response);
    }
}
