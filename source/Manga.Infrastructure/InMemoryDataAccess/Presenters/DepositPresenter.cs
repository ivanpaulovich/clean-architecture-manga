namespace Manga.Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using Manga.Application.Boundaries.Deposit;

    public sealed class DepositPresenter : IOutputPort
    {
        public Collection<string> Errors { get; }
        public Collection<DepositOutput> Deposits { get; }

        public DepositPresenter()
        {
            Errors = new Collection<string>();
            Deposits = new Collection<DepositOutput>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Standard(DepositOutput output)
        {
            Deposits.Add(output);
        }
    }
}