namespace Manga.WebApi.UseCases
{
    using System.Collections.Generic;
    using System;

    public sealed class CustomerDetailsModel
    {
        public Guid CustomerId { get; }
        public string SSN { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; }

        public CustomerDetailsModel(Guid customerId, string ssn, string name, List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            SSN = ssn;
            Name = name;
            Accounts = accounts;
        }
    }
}