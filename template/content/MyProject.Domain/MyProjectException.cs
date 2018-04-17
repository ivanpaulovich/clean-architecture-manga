namespace MyProject.Domain
{
    using System;

    public class MyProjectException : Exception
    {
        internal MyProjectException()
        { }

        internal MyProjectException(string message)
            : base(message)
        { }

        internal MyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
