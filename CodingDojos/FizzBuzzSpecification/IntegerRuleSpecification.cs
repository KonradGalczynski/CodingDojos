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
            var rule = new IntegerRule(outputBuilder);

            rule.Apply(input);

            outputBuilder.Received().Append(input.ToString());
        }

        [Fact]
        public void ShouldCallSuccessorWhenApplyIsCalledAndIsNotBreakable()
        {
            var input = Any.Integer();
            var rule = new IntegerRule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor);

            rule.Apply(input);

            successor.Received().Apply(input);
        }

        [Fact]
        public void ShouldNotCallSuccessorWhenApplyIsCalledAndIsBreakable()
        {
            var input = Any.Integer();
            var rule = new IntegerRule(Any.InstanceOf<IOutputBuilder>());
            var successor = Substitute.For<IRule>();
            rule.ContinueWith(successor).BreakIfApplied();

            rule.Apply(input);

            successor.DidNotReceive().Apply(input);
        }
    }
}