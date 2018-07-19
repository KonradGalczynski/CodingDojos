using CodingDojos;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class DivisibleBy15RuleSpecification
    {
        [Fact]
        public void ShouldProduceFizzBuzzOnOutputWhenApplyForIntegerDivisibleBy15()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy15()
        {
            var input = Any.IntegerNotDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(outputBuilder);
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(15);
            var rule = new DivisibleBy15Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(15);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy15Rule(outputBuilder);
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor).BreakIfApplied();

            rule.Apply(input);

            outputBuilder.Received().Append("FizzBuzz");
            successor.DidNotReceive().Apply(input);
        }
    }
}