using CodingDojos;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification
{
    public class DivisibleBy3RuleSpecification
    {
        [Fact]
        public void ShouldProduceFizzOnOutputWhenApplyForIntegerDivisibleBy3()
        {
            var input = Any.IntegerDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy3Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append("Fizz");
        }

        [Fact]
        public void ShouldProduceNothingOnOutputWhenApplyForIntegerNotDivisibleBy3()
        {
            var input = Any.IntegerNotDivisibleBy(3);
            var outputBuilder = Substitute.For<IOutputBuilder>();
            var rule = new DivisibleBy3Rule(outputBuilder);

            rule.Apply(input);

            outputBuilder.DidNotReceive().Append(Arg.Any<string>());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledRuleMatchesAndIsNotBreakable()
        {
            var input = Any.IntegerDivisibleBy(3);
            var rule = new DivisibleBy3Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndRuleDoesNotMatches()
        {
            var input = Any.IntegerNotDivisibleBy(3);
            var rule = new DivisibleBy3Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.IntegerDivisibleBy(3);
            var rule = new DivisibleBy3Rule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor).BreakIfApplied();

            rule.Apply(input);

            successor.DidNotReceive().Apply(input);
        }
    }
}