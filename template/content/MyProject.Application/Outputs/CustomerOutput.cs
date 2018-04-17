namespace MyProject.Application.Outputs
{
    using System;
    using System.Collections.Generic;

    public class CustomerOutput
    {
        public Guid CustomerId { get; private set; }
        public string Personnummer { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<AccountOutput> Accounts { get; private set; }

        public CustomerOutput()
        {

        }

        public CustomerOutput(
            Guid customerId,
            string personnummer,
            string name,
            List<AccountOutput> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
