namespace Manga.Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;

    public class Credit
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
