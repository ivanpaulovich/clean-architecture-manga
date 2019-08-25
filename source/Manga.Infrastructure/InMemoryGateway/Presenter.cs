namespace Manga.Infrastructure.InMemoryGateway
{
    using System.Collections.ObjectModel;
    using Manga.Application.Boundaries.Transfer;

    public sealed class Presenter:
        Application.Boundaries.Register.IOutputHandler,
        Application.Boundaries.Deposit.IOutputHandler,
        Application.Boundaries.Withdraw.IOutputHandler,
        Application.Boundaries.CloseAccount.IOutputHandler,
        Application.Boundaries.GetAccountDetails.IOutputHandler,
        Application.Boundaries.GetCustomerDetails.IOutputHandler,
        Application.Boundaries.Transfer.IOutputHandler
        {
            public Collection<string> Errors { get; }
            public Collection<Application.Boundaries.Register.RegisterOutput> Registers { get; }
            public Collection<Application.Boundaries.Deposit.DepositOutput> Deposits { get; }
            public Collection<Application.Boundaries.Withdraw.WithdrawOutput> Withdrawals { get; }
            public Collection<Application.Boundaries.CloseAccount.CreateAccountOutput> ClosedAccounts { get; }
            public Collection<Application.Boundaries.GetAccountDetails.GetAccountDetailsOutput> GetAccountDetails { get; }
            public Collection<Application.Boundaries.GetCustomerDetails.GetCustomerDetailsOutput> GetCustomerDetails { get; }
            public Collection<Application.Boundaries.Transfer.TransferOutput> Transfers { get; }
            public Collection<string> NotFounds { get; }

            public Presenter()
            {
                Errors = new Collection<string>();
                Registers = new Collection<Application.Boundaries.Register.RegisterOutput>();
                Deposits = new Collection<Application.Boundaries.Deposit.DepositOutput>();
                Withdrawals = new Collection<Application.Boundaries.Withdraw.WithdrawOutput>();
                ClosedAccounts = new Collection<Application.Boundaries.CloseAccount.CreateAccountOutput>();
                GetAccountDetails = new Collection<Application.Boundaries.GetAccountDetails.GetAccountDetailsOutput>();
                GetCustomerDetails = new Collection<Application.Boundaries.GetCustomerDetails.GetCustomerDetailsOutput>();
                Transfers = new Collection<Application.Boundaries.Transfer.TransferOutput>();
            }

            public void Error(string message)
            {
                Errors.Add(message);
            }

            public void Handle(Application.Boundaries.Register.RegisterOutput output)
            {
                Registers.Add(output);
            }

            public void Handle(Application.Boundaries.Deposit.DepositOutput output)
            {
                Deposits.Add(output);
            }

            public void Handle(Application.Boundaries.Withdraw.WithdrawOutput output)
            {
                Withdrawals.Add(output);
            }

            public void Handle(Application.Boundaries.CloseAccount.CreateAccountOutput output)
            {
                ClosedAccounts.Add(output);
            }

            public void Handle(Application.Boundaries.GetAccountDetails.GetAccountDetailsOutput output)
            {
                GetAccountDetails.Add(output);
            }

            public void Handle(Application.Boundaries.GetCustomerDetails.GetCustomerDetailsOutput output)
            {
                GetCustomerDetails.Add(output);
            }

            public void Handle(TransferOutput output)
            {
                Transfers.Add(output);
            }

            public void NotFound(string message)
            {
                NotFounds.Add(message);
            }
        }
}