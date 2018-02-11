namespace Manga.Application
{
    public interface IOutputBoundary<T>
    {
        T Response { get; }
        void Populate(T response);
    }
}
