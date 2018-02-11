namespace Manga.Domain
{
    public class DomainException : MangaException
    {
        public string BusinessMessage { get; set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
