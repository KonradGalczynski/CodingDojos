using CodingDojos;
using FluentAssertions;
using Xunit;

namespace FizzBuzzSpecification
{
    public class FizzBuzzWorkflowModuleSpecification
    {

        [Theory]
        [InlineData(1, "1")]
        [InlineData(4, "12Fizz4")]
        [InlineData(15, "12Fizz4BuzzFizz78FizzBuzz11Fizz1314FizzBuzz")]
    
        public void ShouldProduceExpectedOutputForGivenInput(int input, string expected)
        {
            var outputBuilder = new OutputBuilder();
            var rulesChain = FizzBuzzWorkflowFactory.Create(outputBuilder);
            var workflow = new RuleWorkflow(rulesChain);
            workflow.Run(input);

            outputBuilder.Build().Should().Be(expected);
        }

    }
}
