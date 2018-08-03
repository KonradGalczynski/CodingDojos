namespace CodingDojos.Rules
{
    public abstract class RuleBase : IRule
    {
        private readonly bool _breakable;
        private readonly IRule _successor;

        protected RuleBase(bool breakable, IRule successor)
        {
            _breakable = breakable;
            _successor = successor;
        }

        public void Apply(int input)
        {
            if (IsRuleMatchingFor(input))
            {
                PerformRuleActionFor(input);
                if (_breakable)
                {
                    return;
                }
            }

            _successor.Apply(input);
        }

        protected abstract void PerformRuleActionFor(int input);

        protected abstract bool IsRuleMatchingFor(int input);
    }
}