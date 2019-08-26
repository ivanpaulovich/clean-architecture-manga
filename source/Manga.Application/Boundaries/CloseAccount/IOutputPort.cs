namespace Manga.Application.Boundaries.CloseAccount
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(CreateAccountOutput createAccountOutput);
    }
}