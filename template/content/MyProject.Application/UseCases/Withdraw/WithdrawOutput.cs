namespace MyProject.Application.UseCases.Withdraw
{
    using MyProject.Application.Outputs;
    public class WithdrawOutput
    {
        public TransactionOutput Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }

        public WithdrawOutput()
        {

        }

        public WithdrawOutput(TransactionOutput transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
