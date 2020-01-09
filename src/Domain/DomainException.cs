namespace Domain
{
    using System;

    /// <summary>
    /// Domain Exception.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="businessMessage">Message.</param>
        public DomainException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
