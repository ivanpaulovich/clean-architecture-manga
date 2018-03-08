namespace MyProject.Domain.Customers
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class AccountCollection
    {
        private List<Guid> items;
        public IReadOnlyCollection<Guid> Items
        {
            get
            {
                return items.AsReadOnly();
            }
            private set
            {
                items = value.ToList();
            }
        }

        public AccountCollection()
        {
            items = new List<Guid>();
        }

        internal void Add(Guid accountId)
        {
            items.Add(accountId);
        }
    }
}
