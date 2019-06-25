namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System;

    public sealed class Input
    {
        public Guid CustomerId { get; }

        public Input(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}