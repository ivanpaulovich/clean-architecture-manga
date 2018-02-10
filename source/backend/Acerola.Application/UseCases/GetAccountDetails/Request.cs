namespace Acerola.Application.UseCases.GetAccountDetails
{
    using System;
    public class Request
    {
        public Guid AccountId { get; private set; }
        public Request(Guid accountId)
        {
            this.AccountId = accountId;
        }
    }
}
