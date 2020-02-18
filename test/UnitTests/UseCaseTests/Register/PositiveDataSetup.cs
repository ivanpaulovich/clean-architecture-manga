namespace UnitTests.UseCaseTests.Register
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal>
    {
        public PositiveDataSetup()
        {
            this.Add(0);
            this.Add(100);
            this.Add(200);
        }
    }
}
