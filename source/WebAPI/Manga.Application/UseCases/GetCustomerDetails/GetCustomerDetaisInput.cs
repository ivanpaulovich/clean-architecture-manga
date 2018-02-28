namespace Manga.Application.UseCases.GetCustomerDetails
{
    using System;

    public class GetCustomerDetaisInput
    {
        public Guid CustomerId { get; private set; }
        public GetCustomerDetaisInput(Guid customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
