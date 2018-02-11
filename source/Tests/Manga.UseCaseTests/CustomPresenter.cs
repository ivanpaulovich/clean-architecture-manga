namespace Manga.UseCaseTests
{
    using Manga.Application;

    public class CustomPresenter<T> : IOutputBoundary<T>
    {
        public T Response { get; private set; }

        public void Populate(T response)
        {
            Response = response;
        }
    }
}
