namespace CodingDojos.Builders
{
    public class DivisibleBy5RuleBuilder : RuleBuilderBase
    {
        protected override IRule CreateConcrete(bool breakable, IRule successor, IOutputBuilder outputBuilder)
        {
            return new DivisibleBy5Rule(breakable, successor, outputBuilder);
        }
    }
}