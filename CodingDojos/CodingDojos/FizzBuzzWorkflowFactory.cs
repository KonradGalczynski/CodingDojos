namespace CodingDojos
{
    public class FizzBuzzWorkflowFactory
    {
        public static IRule Create(IOutputBuilder outputBuilder)
        {
            var divisibleBy15Rule = new DivisibleBy15Rule(outputBuilder);
            var divisibleBy3Rule = new DivisibleBy3Rule(outputBuilder);
            var divisibleBy5Rule = new DivisibleBy5Rule(outputBuilder);
            var integerRule = new IntegerRule(outputBuilder);
            var endOfChain = new NullRule(outputBuilder);
            integerRule.ContinueWith(endOfChain);
            divisibleBy5Rule.BreakIfApplied().ContinueWith(integerRule);
            divisibleBy3Rule.BreakIfApplied().ContinueWith(divisibleBy5Rule);
            divisibleBy15Rule.BreakIfApplied().ContinueWith(divisibleBy3Rule);

            return divisibleBy15Rule;
        }
    }
}