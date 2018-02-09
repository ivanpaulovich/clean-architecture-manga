namespace Acerola.Application.Accounts.Withdraw
{
    using System;

    public class Request
    {
        public Guid AccountId { get; }
        public Double Amount { get; }
    }
}
