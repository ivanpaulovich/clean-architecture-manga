namespace Manga.Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;

    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
    }
}
