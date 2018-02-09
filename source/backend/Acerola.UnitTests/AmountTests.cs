namespace Acerola.Domain.UnitTests
{
    using Acerola.Domain.ValueObjects;
    using Xunit;

    public class AmountTests
    {
        [Fact]
        public void Negative_Amount_Should_Be_Created()
        {
            //
            // Arrange
            double negative = -500;

            //
            // Act and Assert
            Assert.Throws<AmountShouldBePositiveException>(
                () => Amount.Create(negative));
        }

        [Fact]
        public void Positive_Amount_Should_Be_Created()
        {
            //
            // Arrange
            double positive = 500;

            //
            // Act
            Amount amount = Amount.Create(positive);

            //
            // Assert
            Assert.Equal(positive, amount.Value);
        }
    }
}
