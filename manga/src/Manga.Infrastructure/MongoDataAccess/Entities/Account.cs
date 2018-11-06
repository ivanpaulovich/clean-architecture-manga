namespace Manga.Infrastructure.MongoDataAccess.Entities
{
    using System;

    public class Account
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
