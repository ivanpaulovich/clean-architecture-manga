namespace Manga.WebApi.UseCases
{
    using System;
    using System.Collections.Generic;

    public sealed class CustomerDetailsModel
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; }

        public CustomerDetailsModel(Guid customerId, string personnummer, string name, List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
