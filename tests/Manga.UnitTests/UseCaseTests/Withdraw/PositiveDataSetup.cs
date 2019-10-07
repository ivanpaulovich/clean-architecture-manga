namespace Manga.UnitTests.UseCasesTests.Withdraw
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal, decimal>
    {
        public PositiveDataSetup()
        {
            Add(100, 600);
        }
    }
}
