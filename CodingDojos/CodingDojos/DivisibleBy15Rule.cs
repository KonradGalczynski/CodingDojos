namespace CodingDojos
{
    public class DivisibleBy15Rule : IRule
    {
        private readonly IOutputBuilder _outputBuilder;
        private IRule _successor;
        private bool _break;

        public DivisibleBy15Rule(IOutputBuilder outputBuilder)
        {
            _outputBuilder = outputBuilder;
        }

        public void Apply(int input)
        {
            if (input % 15 == 0)
            {
                _outputBuilder.Append("FizzBuzz");
                if (_break)
                {
                    return;
                }
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