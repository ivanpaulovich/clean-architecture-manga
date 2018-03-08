namespace MyProject.Domain
{
    public class DomainException : System.Exception
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
