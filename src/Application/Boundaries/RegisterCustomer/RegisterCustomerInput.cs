namespace Application.Boundaries.RegisterCustomer
{
    using Domain.ValueObjects;

    public sealed class RegisterCustomerInput : IUseCaseInput
    {
        public SSN SSN { get; }
        public Name Name { get; }
        public Username Username { get; }
        public Password Password { get; }
        public PositiveMoney InitialAmount { get; }

        public RegisterCustomerInput(SSN ssn, Name name, Username username, Password password, PositiveMoney initialAmount)
        {
            SSN = ssn;
            Name = name;
            Username = username;
            Password = password;
            InitialAmount = initialAmount;
        }
    }
}
