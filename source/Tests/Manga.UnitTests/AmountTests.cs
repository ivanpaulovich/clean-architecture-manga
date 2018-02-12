namespace Manga.Domain.UnitTests
{
    using Manga.Domain.ValueObjects;
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
                () => new Amount(negative));
        }

        [Fact]
        public void Positive_Amount_Should_Be_Created()
        {
            //
            // Arrange
            double positive = 500;

            //
            // Act
            Amount amount = new Amount(positive);

            //
            // Assert
            Assert.Equal(positive, amount.Value);
        }
    }
}
