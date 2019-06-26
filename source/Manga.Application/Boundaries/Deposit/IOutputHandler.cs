namespace Manga.Application.Boundaries.Deposit
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}