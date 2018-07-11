namespace Manga.Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;

    public class Account
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
