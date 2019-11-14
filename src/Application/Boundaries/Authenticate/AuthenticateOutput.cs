namespace Application.Boundaries.Authenticate
{
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public sealed class AuthenticateOutput : IUseCaseOutput
    {
        public Guid CustomerId { get; }
        public SSN SSN { get; }
        public Name Name { get; }
        public Username Username { get; }
        public string JWTSecret { get; }

        public AuthenticateOutput(ICustomer customer, string jwtSecret)
        {
            Customer customerEntity = (Customer)customer;
            CustomerId = customerEntity.Id;
            SSN = customerEntity.SSN;
            Name = customerEntity.Name;
            Username = customerEntity.Username;
            JWTSecret = jwtSecret;
        }
    }
}
