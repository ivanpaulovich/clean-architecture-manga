namespace Manga.Application.Boundaries.CloseAccount
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}