namespace Manga.Application.UseCases.Register
{
    using Manga.Application.Responses;
    public class RegisterOutput
    {
        public CustomerResponse Customer { get; private set; }
        public AccountResponse Account { get; private set; }

        public RegisterOutput()
        {

        }

        public RegisterOutput(CustomerResponse customer, AccountResponse account)
        {
            Customer = customer;
            Account = account;
        }
    }
}
