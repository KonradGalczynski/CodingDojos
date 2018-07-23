using CodingDojos;
using CodingDojos.Rules;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Rules
{
    public class DivisibleBy15RuleSpecification
    {
        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(15);
            var successor = Substitute.For<IRule>();
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy15Rule(false, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var successor = Substitute.For<IRule>();
            var rule = new DivisibleBy15Rule(true, successor, outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
            successor.DidNotReceive().Apply(input);
        }

        [Fact]
        public void ShouldProduceFizzBuzzOnOutputWhenApplyForIntegerDivisibleBy15()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy15()
        {
            var input = Any.IntegerNotDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(false, Any.InstanceOf<IRule>(), outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }
    }
}