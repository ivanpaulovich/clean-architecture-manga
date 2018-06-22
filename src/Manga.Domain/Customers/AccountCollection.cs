namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using System.Collections.ObjectModel;

    public sealed class AccountCollection : Collection<Guid>
    {
        public void Add(IEnumerable<Guid> accounts)
        {
            foreach (var account in accounts)
            {
                Items.Add(account);
            }
        }
    }
}
