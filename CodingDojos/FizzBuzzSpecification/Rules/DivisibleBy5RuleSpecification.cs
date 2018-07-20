using CodingDojos;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class DivisibleBy5RuleSpecification
    {
        [Fact]
        public void ShouldProduceBuzzOnOutputWhenApplyForIntegerDivisibleBy5()
        {
            var input = Any.IntegerDivisibleBy(5);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy5Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Buzz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy5()
        {
            var input = Any.IntegerNotDivisibleBy(5);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy5Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(5);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy5Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Buzz");
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(5);
            var successor = Substitute.For<IRule>();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy5Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(5);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy5Rule(true, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Buzz");
            successor.DidNotReceive().Apply(input);
        }
    }
}