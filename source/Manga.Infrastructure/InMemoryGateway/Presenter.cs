namespace Manga.Infrastructure.InMemoryGateway
{
    using System;
    using System.Collections.ObjectModel;

    public sealed class Presenter : 
        Manga.Application.Boundaries.Register.IOutputHandler,
        Manga.Application.Boundaries.Deposit.IOutputHandler,
        Manga.Application.Boundaries.Withdraw.IOutputHandler,
        Manga.Application.Boundaries.CloseAccount.IOutputHandler,
        Manga.Application.Boundaries.GetAccountDetails.IOutputHandler,
        Manga.Application.Boundaries.GetCustomerDetails.IOutputHandler
    {
        public Collection<string> Errors { get; }
        public Collection<Manga.Application.Boundaries.Register.Output> Registers { get; }
        public Collection<Manga.Application.Boundaries.Deposit.Output> Deposits { get; }
        public Collection<Manga.Application.Boundaries.Withdraw.Output> Withdrawals { get; }
        public Collection<Guid> ClosedAccounts { get; }
        public Collection<Manga.Application.Boundaries.GetAccountDetails.Output> GetAccountDetails { get; }
        public Collection<Manga.Application.Boundaries.GetCustomerDetails.Output> GetCustomerDetails { get; }


        public Presenter()
        {
            Errors = new Collection<string>();
            Registers = new Collection<Application.Boundaries.Register.Output>();
            Withdrawals = new Collection<Application.Boundaries.Withdraw.Output>();
            ClosedAccounts = new Collection<Guid>();
            GetAccountDetails = new Collection<Application.Boundaries.GetAccountDetails.Output>();
            GetCustomerDetails = new Collection<Application.Boundaries.GetCustomerDetails.Output>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Handle(Manga.Application.Boundaries.Register.Output output)
        {
            Registers.Add(output);
        }

        public void Handle(Manga.Application.Boundaries.Deposit.Output output)
        {
            Deposits.Add(output);
        }

        public void Handle(Application.Boundaries.Withdraw.Output output)
        {
            Withdrawals.Add(output);
        }

        public void Handle(Guid output)
        {
            ClosedAccounts.Add(output);
        }

        public void Handle(Manga.Application.Boundaries.GetAccountDetails.Output output)
        {
            GetAccountDetails.Add(output);
        }

        public void Handle(Application.Boundaries.GetCustomerDetails.Output output)
        {
            GetCustomerDetails.Add(output);
        }
    }
}