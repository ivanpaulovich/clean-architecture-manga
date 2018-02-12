namespace Manga.Domain.UnitTests
{
    using Manga.Domain.ValueObjects;
    using Xunit;

    public class PINTests
    {
        [Fact]
        public void Empty_PIN_Should_Be_Created()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<PINShouldNotBeEmptyException>(
                () => new PIN(empty));
        }

        [Fact]
        public void Valid_PIN_Should_Be_Created()
        {
            //
            // Arrange
            string valid = "08724050601";

            //
            // Act
            PIN pin = new PIN(valid);

            // Assert
            Assert.Equal(valid, pin.Text);
        }
    }
}
