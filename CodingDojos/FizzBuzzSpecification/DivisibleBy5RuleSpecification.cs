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
            var rule = new DivisibleBy5Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Buzz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy5()
        {
            var input = Any.IntegerNotDivisibleBy(5);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy5Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(5);
            var rule = new DivisibleBy5Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(5);
            var rule = new DivisibleBy5Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(5);
            var rule = new DivisibleBy5Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor).BreakIfApplied();

            rule.Apply(input);

            successor.DidNotReceive().Apply(input);
        }
    }
}