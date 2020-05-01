namespace UnitTests.UseCaseTests.Deposit
{
    using Xunit;

    internal sealed class InvalidDataSetup : TheoryData<decimal>
    {
        public InvalidDataSetup() => this.Add(-100);
    }
}
