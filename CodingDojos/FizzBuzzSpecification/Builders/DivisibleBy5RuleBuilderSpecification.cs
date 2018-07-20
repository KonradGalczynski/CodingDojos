using System;
using CodingDojos.Builders;
using CodingDojos.Rules;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Builders
{
    public class DivisibleBy5RuleBuilderSpecification
    {
        [Fact]
        public void ShouldBuildDefaultDivisibleBy5RuleOnRequestWhichHasNoSideEfects()
        {
            var divisibleBy5RuleBuilder = new DivisibleBy5RuleBuilder();

            var rule = divisibleBy5RuleBuilder.Build();

            Action act = () => rule.Apply(Any.Integer());
            act.Should().NotThrow();
        }

        [Fact]
        public void ShouldBuildDivisibleBy5RuleOnRequest()
        {
            var divisibleBy5RuleBuilder = new DivisibleBy5RuleBuilder();

            var rule = divisibleBy5RuleBuilder.Build();

            rule.GetType().Should().Be<DivisibleBy5Rule>();
            rule.GetType().Should().BeAssignableTo<IRule>();
        }
    }
}