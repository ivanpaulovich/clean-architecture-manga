namespace Manga.UseCaseTests
{
    using Manga.Application;

    public class CustomPresenter<T> : IOutputBoundary<T>
    {
        public T Output { get; private set; }

        public void Populate(T response)
        {
            Output = response;
        }
    }
}
