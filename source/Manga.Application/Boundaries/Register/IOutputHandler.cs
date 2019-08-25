namespace Manga.Application.Boundaries.Register
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(RegisterOutput output);
    }
}