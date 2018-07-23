using System;
using CodingDojos.Builders;
using CodingDojos.Rules;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace FizzBuzzSpecification.Builders
{
    public class IntegerRuleBuilderSpecification
    {
        [Fact]
        public void ShouldBuildIntegerRuleOnRequest()
        {
            var integerRuleBuilder = new IntegerRuleBuilder();

            var rule = integerRuleBuilder.Build();

            rule.GetType().Should().Be<IntegerRule>();
            rule.GetType().Should().BeAssignableTo<IRule>();
        }

        [Fact]
        public void ShouldBuildDefaultIntegerRuleOnRequestWhichHasNoSideEfects()
        {
            var integerRuleBuilder = new IntegerRuleBuilder();

            var rule = integerRuleBuilder.Build();

            Action act = () => rule.Apply(Any.Integer());
            act.Should().NotThrow();
        }
    }
}
