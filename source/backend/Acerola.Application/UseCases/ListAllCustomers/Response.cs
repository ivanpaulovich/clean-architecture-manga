namespace Acerola.Application.UseCases.ListAllCustomers
{
    using System.Collections.Generic;

    public class Response
    {
        public IReadOnlyList<CustomerResponse> Customers { get; private set; }

        public Response(List<CustomerResponse> customers)
        {
            Customers = customers;
        }
    }
}
