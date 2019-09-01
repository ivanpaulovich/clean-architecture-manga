namespace Manga.UnitTests.UseCasesTests.Register
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<double>
    {
        public PositiveDataSetup()
        {
            Add(0);
            Add(100);
            Add(200);
        }
    }
}