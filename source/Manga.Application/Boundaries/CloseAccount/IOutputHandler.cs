namespace Manga.Application.Boundaries.CloseAccount
{
    using System;

    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Guid output);
    }
}