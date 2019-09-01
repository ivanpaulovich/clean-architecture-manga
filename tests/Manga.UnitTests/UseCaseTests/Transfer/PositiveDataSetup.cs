namespace Manga.UnitTests.UseCaseTests.Transfer
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