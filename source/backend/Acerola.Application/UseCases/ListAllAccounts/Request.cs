namespace Acerola.Application.UseCases.ListAllAccounts
{
    using System;

    public class Request
    {
        public Guid? CustomerId { get; }

        public Request(Guid? customerId)
        {
            CustomerId = customerId;
        }
    }
}
