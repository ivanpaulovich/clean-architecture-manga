namespace MyProject.Application.UseCases.GetCustomerDetails
{
    using System;

    public class GetCustomerDetailsInput
    {
        public Guid CustomerId { get; private set; }
        public GetCustomerDetailsInput(Guid customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
