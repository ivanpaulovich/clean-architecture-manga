namespace Domain
{
    using System;

    public class DomainException : Exception
    {
        public DomainException(string businessMessage) : base(businessMessage) { }
    }
}