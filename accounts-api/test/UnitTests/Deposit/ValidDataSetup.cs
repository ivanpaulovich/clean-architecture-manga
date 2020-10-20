namespace UnitTests.Deposit
{
    using Xunit;

    internal sealed class ValidDataSetup : TheoryData<decimal>
    {
        public ValidDataSetup()
        {
            this.Add(100);
            this.Add(200);
        }
    }
}
