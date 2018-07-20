using CodingDojos.Rules;

namespace CodingDojos.Builders
{
    public class DivisibleBy3RuleBuilder : RuleBuilderBase
    {
        protected override IRule CreateConcrete(bool breakable, IRule successor, IOutputBuilder outputBuilder)
        {
            return new DivisibleBy3Rule(breakable, successor, outputBuilder);
        }
    }
}