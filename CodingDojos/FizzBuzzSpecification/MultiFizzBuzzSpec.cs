using CodingDojos;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class MultiFizzBuzzSpec
    {
        [Fact]
        public void FizzBuzzing7ShouldReturn12Fizz4Buzz67()
        {
            // Given
            var n = 7;

            // When
            var fizzbuzzed = MultiFizzBuzzer.FizzBuzz(n);

            // Then
            Assert.Equal("12Fizz4BuzzFizz7", fizzbuzzed);
        }

        [Fact]
        public void FizzBuzzing15ShouldReturnCorrectString()
        {
            // Given
            var n = 15;

            // When
            var fizzbuzzed = MultiFizzBuzzer.FizzBuzz(n);

            // Then
            Assert.Equal("12Fizz4BuzzFizz78FizzBuzz11Fizz1314FizzBuzz", fizzbuzzed);
        }

        [Fact]
        public void SingleFizzBuzzing15ShouldReturnFizzBuzz()
        {
            // Given
            var n = 15;

            // When
            var singleFizzBuzzer = new SingleFizzBuzzer();
            var fizzbuzzed = singleFizzBuzzer.SingleFizzBuzz(n);

            // Then
            Assert.Equal("FizzBuzz", fizzbuzzed);
        }

    }
}
