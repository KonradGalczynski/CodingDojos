namespace CodingDojos
{
    public class DivisibleBy5Rule : IRule
    {
        private readonly IOutputBuilder _outputBuilder;
        private IRule _successor;
        private bool _break;

        public DivisibleBy5Rule(IOutputBuilder outputBuilder)
        {
            _outputBuilder = outputBuilder;
        }

        public void Apply(int input)
        {
            if (input % 5 == 0)
            {
                _outputBuilder.Append("Buzz");
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