using CodingDojos.Rules;

namespace CodingDojos.Builders
{
    public class IntegerRuleBuilder : RuleBuilderBase
    {
        protected override IRule CreateConcrete(bool breakable, IRule successor, IOutputBuilder outputBuilder)
        {
            return new IntegerRule(breakable, successor, outputBuilder);
        }
    }
}