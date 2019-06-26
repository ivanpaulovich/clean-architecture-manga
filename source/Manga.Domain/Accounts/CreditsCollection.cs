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

        public CreditsCollection(IList<Credit> credits) : this()
        {
            foreach (var credit in credits)
                Add(credit);
        }

        public void Add(ICredit credit)
        {
            _credits.Add(credit);
        }

        public IReadOnlyCollection<ICredit> GetTransactions()
        {
            var transactions = new ReadOnlyCollection<ICredit>(_credits);
            return transactions;
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