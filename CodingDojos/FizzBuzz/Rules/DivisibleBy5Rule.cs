namespace CodingDojos.Rules
{
    public class DivisibleBy5Rule : RuleBase
    {
        private readonly IOutputBuilder _outputBuilder;

        public DivisibleBy5Rule(bool breakable, IRule successor, IOutputBuilder outputBuilder)
            : base(breakable, successor)
        {
            _outputBuilder = outputBuilder;
        }

        protected override void PerformRuleActionFor(int input)
        {
            _outputBuilder.Append("Buzz");
        }

        protected override bool IsRuleMatchingFor(int input)
        {
            return input % 5 == 0;
        }
    }
}