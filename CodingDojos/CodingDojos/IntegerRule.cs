namespace CodingDojos
{
    public class IntegerRule : IRule
    {
        private readonly IOutputBuilder _outputBuilder;
        private IRule _successor;
        private bool _break;

        public IntegerRule(IOutputBuilder outputBuilder)
        {
            _outputBuilder = outputBuilder;
        }

        public void Apply(int input)
        {
            _outputBuilder.Append(input.ToString());
            if (_break)
            {
                return;
            }
            _successor?.Apply(input);
        }

        public IRule ContinueWith(IRule rule)
        {
            _successor = rule;
            return this;
        }

        public IRule BreakIfApplied()
        {
            _break = true;
            return this;
        }
    }
}