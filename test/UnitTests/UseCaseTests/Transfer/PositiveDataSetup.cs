namespace UnitTests.UseCaseTests.Transfer
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal, decimal>
    {
        public PositiveDataSetup()
        {
            Add(100, 400);
        }
    }
}
