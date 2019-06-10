namespace Manga.WebApi.UseCases.Register
{
    using System.Collections.Generic;
    using System;

    public class CustomerModel
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; set; }

        public CustomerModel(
            Guid customerId,
            string perssonnummer,
            string name,
            List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            Personnummer = perssonnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}