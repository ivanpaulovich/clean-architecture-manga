namespace UnitTests.Deposit
{
    using Xunit;

    internal sealed class InvalidDataSetup : TheoryData<decimal>
    {
        public InvalidDataSetup()
        {
            this.Add(-100);
            this.Add(0);
        }
    }
}
