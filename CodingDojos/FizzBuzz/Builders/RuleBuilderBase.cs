using CodingDojos.Rules;

namespace CodingDojos.Builders
{
    public abstract class RuleBuilderBase : IRuleBuilder
    {
        private bool _break;
        private IOutputBuilder _outputBuilder;
        private IRule _successor;


        public IRuleBuilder RedirectResultTo(IOutputBuilder outputBuilder)
        {
            _outputBuilder = outputBuilder;
            return this;
        }

        public IRuleBuilder ContinueWith(IRule rule)
        {
            _successor = rule;
            return this;
        }

        public IRuleBuilder BreakIfApplied()
        {
            _break = true;
            return this;
        }

        public IRule Build()
        {
            if (_successor == null) _successor = new NullRule();
            if (_outputBuilder == null) _outputBuilder = new NullOutputBuilder();

            return CreateConcrete(_break, _successor, _outputBuilder);
        }

        protected abstract IRule CreateConcrete(bool breakable, IRule successor, IOutputBuilder outputBuilder);
    }
}