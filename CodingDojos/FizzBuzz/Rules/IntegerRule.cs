namespace CodingDojos.Rules
{
    public class IntegerRule : RuleBase
    {
        private readonly IOutputBuilder _outputBuilder;

        public IntegerRule(bool breakable, IRule successor, IOutputBuilder outputBuilder)
        : base(breakable, successor)
        {
            _outputBuilder = outputBuilder;
        }

        protected override void PerformRuleActionFor(int input)
        {
            _outputBuilder.Append(input.ToString());
        }

        protected override bool IsRuleMatchingFor(int input)
        {
            return true;
        }
    }
}