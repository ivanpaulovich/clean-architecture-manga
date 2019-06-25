namespace Manga.Infrastructure.InMemoryGateway
{
    using System.Collections.ObjectModel;

    public sealed class Presenter : 
        Application.Boundaries.Register.IOutputHandler,
        Application.Boundaries.Deposit.IOutputHandler,
        Application.Boundaries.Withdraw.IOutputHandler,
        Application.Boundaries.CloseAccount.IOutputHandler,
        Application.Boundaries.GetAccountDetails.IOutputHandler,
        Application.Boundaries.GetCustomerDetails.IOutputHandler
    {
        public Collection<string> Errors { get; }
        public Collection<Application.Boundaries.Register.Output> Registers { get; }
        public Collection<Application.Boundaries.Deposit.Output> Deposits { get; }
        public Collection<Application.Boundaries.Withdraw.Output> Withdrawals { get; }
        public Collection<Application.Boundaries.CloseAccount.Output> ClosedAccounts { get; }
        public Collection<Application.Boundaries.GetAccountDetails.Output> GetAccountDetails { get; }
        public Collection<Application.Boundaries.GetCustomerDetails.Output> GetCustomerDetails { get; }


        public Presenter()
        {
            Errors = new Collection<string>();
            Registers = new Collection<Application.Boundaries.Register.Output>();
            Deposits = new Collection<Application.Boundaries.Deposit.Output>();
            Withdrawals = new Collection<Application.Boundaries.Withdraw.Output>();
            ClosedAccounts = new Collection<Application.Boundaries.CloseAccount.Output>();
            GetAccountDetails = new Collection<Application.Boundaries.GetAccountDetails.Output>();
            GetCustomerDetails = new Collection<Application.Boundaries.GetCustomerDetails.Output>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Handle(Application.Boundaries.Register.Output output)
        {
            Registers.Add(output);
        }

        public void Handle(Application.Boundaries.Deposit.Output output)
        {
            Deposits.Add(output);
        }

        public void Handle(Application.Boundaries.Withdraw.Output output)
        {
            Withdrawals.Add(output);
        }

        public void Handle(Application.Boundaries.CloseAccount.Output output)
        {
            ClosedAccounts.Add(output);
        }

        public void Handle(Application.Boundaries.GetAccountDetails.Output output)
        {
            GetAccountDetails.Add(output);
        }

        public void Handle(Application.Boundaries.GetCustomerDetails.Output output)
        {
            GetCustomerDetails.Add(output);
        }
    }
}