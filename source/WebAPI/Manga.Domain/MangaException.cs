namespace Manga.Domain
{
    using System;

    public class MangaException : Exception
    {
        public MangaException()
        { }

        public MangaException(string message)
            : base(message)
        { }

        public MangaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
