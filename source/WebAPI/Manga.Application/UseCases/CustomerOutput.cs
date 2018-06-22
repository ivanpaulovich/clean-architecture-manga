namespace Manga.Application.UseCases
{
    using Manga.Domain.Customers;
    using System;
    using System.Collections.Generic;

    public sealed class CustomerOutput
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public IReadOnlyList<AccountOutput> Accounts { get; }

        public CustomerOutput(
            Customer customer,
            List<AccountOutput> accounts)
        {
            CustomerId = customer.Id;
            Personnummer = customer.SSN;
            Name = customer.Name;
            Accounts = accounts;
        }
    }
}
