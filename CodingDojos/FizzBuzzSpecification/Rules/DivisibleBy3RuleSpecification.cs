using CodingDojos;
using CodingDojos.Rules;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Rules
{
    public class DivisibleBy3RuleSpecification
    {
        [Fact]
        public void ShouldProduceFizzOnOutputWhenApplyForIntegerDivisibleBy3()
        {
            var input = Any.IntegerDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy3Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Fizz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy3()
        {
            var input = Any.IntegerNotDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy3Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy3Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Fizz");
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(3);
            var successor = Substitute.For<IRule>();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy3Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy3Rule(true, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Fizz");
            successor.DidNotReceive().Apply(input);
        }
    }
}