namespace UnitTests.UseCaseTests.Deposit
{
    using Xunit;

    internal sealed class NegativeDataSetup : TheoryData<decimal>
    {
        public NegativeDataSetup()
        {
            this.Add(-100);
        }
    }
}
