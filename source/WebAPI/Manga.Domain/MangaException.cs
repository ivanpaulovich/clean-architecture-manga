namespace Manga.Domain
{
    using System;

    public class MangaException : Exception
    {
        internal MangaException()
        { }

        internal MangaException(string message)
            : base(message)
        { }

        internal MangaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
