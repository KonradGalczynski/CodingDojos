using System;
using CodingDojos.Builders;
using CodingDojos.Rules;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Builders
{
    public class DivisibleBy3RuleBuilderSpecification
    {
        [Fact]
        public void ShouldBuildDefaultDivisibleBy3RuleOnRequestWhichHasNoSideEfects()
        {
            var divisibleBy3RuleBuilder = new DivisibleBy3RuleBuilder();

            var rule = divisibleBy3RuleBuilder.Build();

            Action act = () => rule.Apply(Any.Integer());
            act.Should().NotThrow();
        }

        [Fact]
        public void ShouldBuildDivisibleBy3RuleOnRequest()
        {
            var divisibleBy3RuleBuilder = new DivisibleBy3RuleBuilder();

            var rule = divisibleBy3RuleBuilder.Build();

            rule.GetType().Should().Be<DivisibleBy3Rule>();
            rule.GetType().Should().BeAssignableTo<IRule>();
        }
    }
}
