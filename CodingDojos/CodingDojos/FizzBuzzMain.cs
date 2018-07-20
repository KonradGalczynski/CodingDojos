using System;
using CodingDojos.Workflow;

namespace CodingDojos
{
    // requirements:
    // - write a program that prints to the console the numbers from 1 to N where N is supplied by user.\
    // - for multiples of three print “Fizz” instead of the number
    // - for the multiples of five print “Buzz”
    // - for numbers which are multiples of both three and five print “FizzBuzz”
    internal class FizzBuzzMain
    {
        public static void Main(string[] args)
        {
            var outputBuilder = new OutputBuilder();
            var worflow = new RuleWorkflow(FizzBuzzWorkflowFactory.Create(outputBuilder));
            var input = int.Parse(Console.ReadLine());
            worflow.Run(input);
            Console.WriteLine(outputBuilder.Build());
            Console.ReadKey();
        }
    }
}