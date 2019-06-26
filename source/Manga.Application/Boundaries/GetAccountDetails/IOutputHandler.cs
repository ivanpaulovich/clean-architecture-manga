namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System;

    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}