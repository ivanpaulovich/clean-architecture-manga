namespace Acerola.UI.Requests
{
    using System;
    public class WithdrawRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}
