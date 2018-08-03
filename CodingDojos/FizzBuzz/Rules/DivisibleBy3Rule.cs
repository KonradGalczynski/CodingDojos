namespace CodingDojos.Rules
{
    public class DivisibleBy3Rule : RuleBase
    {
        private readonly IOutputBuilder _outputBuilder;

        public DivisibleBy3Rule(bool breakable, IRule successor, IOutputBuilder outputBuilder)
            : base(breakable, successor)
        {
            _outputBuilder = outputBuilder;
        }

        protected override void PerformRuleActionFor(int input)
        {
            _outputBuilder.Append("Fizz");
        }

        protected override bool IsRuleMatchingFor(int input)
        {
            return input % 3 == 0;
        }
    }
}