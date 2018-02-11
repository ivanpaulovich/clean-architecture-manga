namespace Manga.Application
{
    using System.Threading.Tasks;

    public interface IInputBoundary<T>
    {
        Task Handle(T request);
    }
}
