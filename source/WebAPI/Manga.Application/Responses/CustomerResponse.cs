namespace Manga.Application.Responses
{
    using System;
    using System.Collections.Generic;

    public class CustomerResponse
    {
        public Guid CustomerId { get; private set; }
        public string Personnummer { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<AccountResponse> Accounts { get; private set; }

        public CustomerResponse()
        {

        }

        public CustomerResponse(Guid customerId, string personnummer, string name,
            List<AccountResponse> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
