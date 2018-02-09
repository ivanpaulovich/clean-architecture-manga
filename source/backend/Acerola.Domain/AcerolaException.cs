namespace Acerola.Domain
{
    using System;

    public class AcerolaException : Exception
    {
        public AcerolaException()
        { }

        public AcerolaException(string message)
            : base(message)
        { }

        public AcerolaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
