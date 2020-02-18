namespace UnitTests.UseCaseTests.CloseAccount
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal>
    {
        public PositiveDataSetup()
        {
            this.Add(0.5M);
            this.Add(100M);
            this.Add(200M);
        }
    }
}
