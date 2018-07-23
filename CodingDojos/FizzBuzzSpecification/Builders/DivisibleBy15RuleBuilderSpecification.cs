using System;
using CodingDojos.Builders;
using CodingDojos.Rules;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Builders
{
    public class DivisibleBy15RuleBuilderSpecification
    {
        [Fact]
        public void ShouldBuildDivisibleBy15RuleOnRequest()
        {
            var divisibleBy15RuleBuilder = new DivisibleBy15RuleBuilder();

            var rule = divisibleBy15RuleBuilder.Build();

            rule.GetType().Should().Be<DivisibleBy15Rule>();
            rule.GetType().Should().BeAssignableTo<IRule>();
        }

        [Fact]
        public void ShouldBuildDefaultDivisibleBy15RuleOnRequestWhichHasNoSideEfects()
        {
            var divisibleBy15RuleBuilder = new DivisibleBy15RuleBuilder();

            var rule = divisibleBy15RuleBuilder.Build();

            Action act = () => rule.Apply(Any.Integer());
            act.Should().NotThrow();
        }
    }
}