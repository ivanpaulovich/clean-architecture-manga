namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System;

    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}