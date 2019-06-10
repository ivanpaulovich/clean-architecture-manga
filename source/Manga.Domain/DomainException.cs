namespace Manga.Domain
{
    using System;

    public class DomainException : Exception
    {
        internal DomainException(string businessMessage) : base(businessMessage)
        { }
    }
}