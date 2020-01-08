namespace Domain.Accounts.Credits
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;

    public sealed class CreditsCollection
    {
        private readonly IList<ICredit> _credits;

        public CreditsCollection()
        {
            this._credits = new List<ICredit>();
        }

        public void Add<T>(IEnumerable<T> credits)
            where T : ICredit
        {
            foreach (var credit in credits)
            {
                this.Add(credit);
            }
        }

        public void Add(ICredit credit) => this._credits.Add(credit);

        public IReadOnlyCollection<ICredit> GetTransactions()
        {
            var transactions = new ReadOnlyCollection<ICredit>(this._credits);
            return transactions;
        }

        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            foreach (ICredit credit in this._credits)
            {
                total = credit.Sum(total);
            }

            return total;
        }
    }
}
