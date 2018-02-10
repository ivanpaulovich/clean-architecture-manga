namespace Acerola.UI.Requests
{
    using System;
    public class DepositRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}
