using CodingDojos;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class IntegerRuleSpecification
    {
        [Fact]
        public void ShouldStringifyGivenIntegerWhenApplyIsCalled()
        {
            var input = Any.Integer();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new IntegerRule(Any.Boolean(), Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append(input.ToString());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndIsNotBreakable()
        {
            var input = Any.Integer();
            var successor = Substitute.For<IRule>();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new IntegerRule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append(input.ToString());
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.Integer();
            var successor = Substitute.For<IRule>();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new IntegerRule(true, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append(input.ToString());
            successor.DidNotReceive().Apply(input);
        }
    }
}