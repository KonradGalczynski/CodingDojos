using CodingDojos;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class NullOutputBuilderSpecification
    {
        [Fact]
        public void ShouldProduceStringEmptyOnBuildWhenNoAppendWasCalled()
        {
            var outputBuilder = new NullOutputBuilder();

            var result = outputBuilder.Build();

            result.Should().BeEmpty();
        }

        [Fact]
        public void ShouldProduceStringEmptyOnBuildWhenAppendWasCalledAnyNumberOfTimes()
        {
            var outputBuilder = new NullOutputBuilder();

            var numOfAppends = Any.Integer();
            for (var i = 0; i < numOfAppends; i++)
            {
                outputBuilder.Append(Any.String());
            }
            var result = outputBuilder.Build();

            result.Should().BeEmpty();
        }
    }
}