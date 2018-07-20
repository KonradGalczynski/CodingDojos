namespace CodingDojos.Rules
{
    public class DivisibleBy15Rule : RuleBase
    {
        private readonly IOutputBuilder _outputBuilder;

        public DivisibleBy15Rule(bool breakable, IRule successor, IOutputBuilder outputBuilder)
            : base(breakable, successor)
        {
            _outputBuilder = outputBuilder;
        }

        protected override void PerformRuleActionFor(int input)
        {
            _outputBuilder.Append("FizzBuzz");
        }

        protected override bool IsRuleMatchingFor(int input)
        {
            return input % 15 == 0;
        }
    }
}