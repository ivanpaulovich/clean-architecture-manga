namespace Acerola.Application.Accounts.Close
{
    using System;

    public class RequestModel
    {
        public Guid AccountId { get; private set; }

        public RequestModel(Guid guid)
        {
            this.AccountId = guid;
        }
    }
}
