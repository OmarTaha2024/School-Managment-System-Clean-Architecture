using FluentAssertions;
namespace SchoolManagment.XUnitTest
{
    public class AssertTest
    {
        [Fact]
        public void calculate_5_Sum_6_Shuld_be_11_without_Fluent_Assertion()
        {
            // Arrange
            int x = 5; int y = 6;
            //Act
            int z = x + y;
            //Assert
            Assert.Equal(11, z);
        }
        [Fact]
        public void calculate_5_Sum_6_Shuld_be_11_with_Fluent_Assertion()
        {
            // Arrange
            int x = 5; int y = 6;
            //Act
            int z = x + y;
            //Assert
            z.Should().Be(11);
        }
        [Fact]
        public void string_should_start_with()
        {
            // Arrange
            string word = "Hello";
            word.Should().StartWith("He");
        }
        [Fact]
        public void string_should_end_with()
        {
            // Arrange
            string word = "Hello";
            word.Should().EndWith("He");
        }
    }
}