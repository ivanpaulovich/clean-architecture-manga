namespace Acerola.Domain.UnitTests
{
    using Acerola.Domain.ValueObjects;
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
                () => PIN.Create(empty));
        }

        [Fact]
        public void Valid_PIN_Should_Be_Created()
        {
            //
            // Arrange
            string valid = "08724050601";

            //
            // Act
            PIN pin = PIN.Create(valid);

            // Assert
            Assert.Equal(valid, pin.Text);
        }
    }
}
