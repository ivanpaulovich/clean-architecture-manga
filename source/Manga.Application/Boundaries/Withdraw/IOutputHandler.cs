namespace Manga.Application.Boundaries.Withdraw
{
    using System;

    public interface IOutputHandler
    {
        void Handle(Output output);
        void Error(string message);
    }
}