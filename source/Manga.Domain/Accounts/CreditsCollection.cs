namespace Manga.Domain.Accounts
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Manga.Domain.ValueObjects;

    public sealed class CreditsCollection
    {
        private readonly IList<ICredit> _credits;

        public CreditsCollection()
        {
            _credits = new List<ICredit>();
        }

        public IReadOnlyCollection<ICredit> GetTransactions()
        {
            var transactions = new ReadOnlyCollection<ICredit>(_credits);
            return transactions;
        }

        public void Add(ICredit credit)
        {
            _credits.Add(credit);
        }

        public PositiveAmount GetTotal()
        {
            PositiveAmount total = new PositiveAmount(0);

            foreach (ICredit credit in _credits)
            {
                total = credit.Sum(total);
            }

            return total;
        }
    }
}