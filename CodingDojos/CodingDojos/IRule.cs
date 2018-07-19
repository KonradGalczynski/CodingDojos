namespace CodingDojos
{
    public interface IRule
    {
        void Apply(int input);
        IRule ContinueWith(IRule rule);
        IRule BreakIfApplied();
    }

    public class NullRule : IRule
    {
        private bool _break;

        public NullRule(IOutputBuilder outputBuilder)
        {
        }

        public IRule ContinueWith(IRule rule)
        {
            return this;
        }

        public IRule BreakIfApplied()
        {
            _break = true;
            return this;
        }

        public void Apply(int input)
        {
        }
    }
}