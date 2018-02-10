namespace Acerola.Application.UseCases.ListAllCustomers
{
    using System;
    public class CustomerResponse
    {
        public Guid CustomerId { get; set; }
        public string Personnummer { get; set; }
        public string Name { get; set; }
    }
}
