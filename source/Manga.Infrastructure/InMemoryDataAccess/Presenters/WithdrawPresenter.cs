namespace Manga.Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using Manga.Application.Boundaries.Withdraw;

    public sealed class WithdrawPresenter : IOutputPort
    {
        public Collection<string> Errors { get; }
        public Collection<WithdrawOutput> Withdrawals { get; }

        public WithdrawPresenter()
        {
            Errors = new Collection<string>();
            Withdrawals = new Collection<WithdrawOutput>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Default(WithdrawOutput output)
        {
            Withdrawals.Add(output);
        }
    }
}