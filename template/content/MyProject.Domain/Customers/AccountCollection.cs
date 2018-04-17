namespace MyProject.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using System.Collections.ObjectModel;

    public class AccountCollection : Collection<Guid>
    {
        public AccountCollection()
        {

        }

        public AccountCollection(IEnumerable<Guid> list)
        {
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }
    }
}
