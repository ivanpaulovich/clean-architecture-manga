namespace Manga.UI.Model
{
    using System;
    using System.Collections.Generic;

    public class RegisterModel
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; set; }

        public RegisterModel(Guid customerId, string perssonnummer, string name, List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            Personnummer = perssonnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
