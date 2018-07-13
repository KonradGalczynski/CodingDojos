using FluentAssertions;
using Xunit;

namespace FizzBuzzSpecification
{
    public class FizzBuzzSpecification
    {
        [Fact]
        public void ShouldSumTwoIntegers()
        {
            //Given
            const int a = 2;
            const int b = 4;

            //When
            const int c = a + b;

            //Then
            c.Should().Be(6);
        }
    }
}
