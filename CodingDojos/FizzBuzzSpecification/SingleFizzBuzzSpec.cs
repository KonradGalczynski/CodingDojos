using CodingDojos;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class SingleFizzBuzzSpec
    {
        [Fact]
        public void SingleFizzBuzzing1ShouldReturn1()
        {
            // Given
            var n = 1;

            // When
            var fizzbuzzed = new SingleFizzBuzzer().Calc(n);

            // Then
            Assert.Equal("1", fizzbuzzed);
        }

        [Fact]
        public void SingleFizzBuzzing3ShouldReturnFizz()
        {
            // Given
            var n = 3;

            // When
            var fizzbuzzed = new SingleFizzBuzzer().Calc(n);

            // Then
            Assert.Equal("Fizz", fizzbuzzed);
        }

        [Fact]
        public void SingleFizzBuzzing5ShouldReturnBuzz()
        {
            // Given
            var n = 5;

            // When
            var fizzbuzzed = new SingleFizzBuzzer().Calc(n);

            // Then
            Assert.Equal("Buzz", fizzbuzzed);
        }

        [Fact]
        public void SingleFizzBuzzing15ShouldReturnFizzBuzz()
        {
            // Given
            var n = 15;

            // When
            var fizzbuzzed = new SingleFizzBuzzer().Calc(n);

            // Then
            Assert.Equal("FizzBuzz", fizzbuzzed);
        }

    }
}
