namespace Acerola.Application.Accounts.Deposit
{
    using System;

    public class Request
    {
        public Guid AccountId { get; set; }
        public Double MoneyAmount { get; set; }
    }
}
