namespace Acerola.Application.Accounts.Close
{
    using System;

    public class Request
    {
        public Guid AccountId { get; private set; }

        public Request(Guid guid)
        {
            this.AccountId = guid;
        }
    }
}
