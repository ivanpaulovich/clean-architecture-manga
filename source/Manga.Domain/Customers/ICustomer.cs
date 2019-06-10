namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;

    public interface ICustomer : IAggregateRoot
    {
        IReadOnlyCollection<Guid> Accounts { get; }
        void Register(Guid accountId);
    }
}