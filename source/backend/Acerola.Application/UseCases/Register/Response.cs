namespace Acerola.Application.UseCases.Register
{
    using Acerola.Application.Responses;
    public class Response
    {
        public CustomerResponse Customer { get; private set; }
        public AccountResponse Account { get; private set; }

        public Response()
        {

        }

        public Response(CustomerResponse customer, AccountResponse account)
        {
            Customer = customer;
            Account = account;
        }
    }
}
