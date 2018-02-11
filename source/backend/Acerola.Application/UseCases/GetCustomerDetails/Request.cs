namespace Acerola.Application.UseCases.GetCustomerDetails
{
    using System;

    public class Request
    {
        public Guid CustomerId { get; private set; }
        public Request(Guid customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
