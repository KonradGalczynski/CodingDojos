using CodingDojos.Rules;

namespace CodingDojos.Builders
{
    public class DivisibleBy15RuleBuilder : RuleBuilderBase
    {
        protected override IRule CreateConcrete(bool breakable, IRule successor, IOutputBuilder outputBuilder)
        {
            return new DivisibleBy15Rule(breakable, successor, outputBuilder);
        }
    }
}