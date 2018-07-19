namespace CodingDojos
{
    public class RuleWorkflow
    {
        private readonly IRule _rulesChain;

        public RuleWorkflow(IRule rulesChain)
        {
            _rulesChain = rulesChain;
        }

        public void Run(int input)
        {
            for (var i = 1; i <= input; i++)
                _rulesChain.Apply(i);
        }
    }
}