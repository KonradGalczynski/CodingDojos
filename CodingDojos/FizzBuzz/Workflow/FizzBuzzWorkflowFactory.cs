using CodingDojos.Builders;
using CodingDojos.Rules;

namespace CodingDojos.Workflow
{
    public class FizzBuzzWorkflowFactory
    {
        public static IRule Create(IOutputBuilder outputBuilder)
        {
            var by15RuleBuilder = new DivisibleBy15RuleBuilder().RedirectResultTo(outputBuilder);
            var by3RuleBuilder = new DivisibleBy3RuleBuilder().RedirectResultTo(outputBuilder);
            var by5RuleBuilder = new DivisibleBy5RuleBuilder().RedirectResultTo(outputBuilder);
            var integerRuleBuilder = new IntegerRuleBuilder().RedirectResultTo(outputBuilder);
            var endOfChain = new NullRule();
            integerRuleBuilder.ContinueWith(endOfChain);
            by5RuleBuilder.BreakIfApplied().ContinueWith(integerRuleBuilder.Build());
            by3RuleBuilder.BreakIfApplied().ContinueWith(by5RuleBuilder.Build());
            by15RuleBuilder.BreakIfApplied().ContinueWith(by3RuleBuilder.Build());

            return by15RuleBuilder.Build();
        }
    }
}