namespace Acerola.Application.UseCases.CloseAccount
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
