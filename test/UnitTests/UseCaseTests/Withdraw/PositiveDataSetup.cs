namespace UnitTests.UseCaseTests.Withdraw
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal, decimal>
    {
        public PositiveDataSetup()
        {
            this.Add(100, 400);
        }
    }
}
