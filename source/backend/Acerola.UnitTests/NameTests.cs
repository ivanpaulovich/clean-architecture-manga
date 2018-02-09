namespace Acerola.Domain.UnitTests
{
    using Acerola.Domain.ValueObjects;
    using Xunit;

    public class NameTests
    {
        [Fact]
        public void Empty_Name_Should_Be_Created()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<NameShouldNotBeEmptyException>(
                () => Name.Create(empty));
        }

        [Fact]
        public void Full_Name_Shoud_Be_Created()
        {
            //
            // Arrange
            string valid = "Ivan Paulovich";

            //
            // Act
            Name name = Name.Create(valid);

            //
            // Assert
            Assert.Equal(valid, name.Text);
        }
    }
}
