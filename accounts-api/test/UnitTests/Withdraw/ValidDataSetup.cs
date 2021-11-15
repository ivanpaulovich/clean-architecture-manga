namespace UnitTests.Withdraw;

using Xunit;

internal sealed class ValidDataSetup : TheoryData<decimal, decimal>
{
    public ValidDataSetup() => this.Add(100, 400);
}
