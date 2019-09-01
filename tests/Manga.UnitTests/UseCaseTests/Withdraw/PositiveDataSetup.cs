namespace Manga.UnitTests.UseCasesTests.Withdraw
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<double, double>
    {
        public PositiveDataSetup()
        {
            Add(100, 600);
        }
    }
}