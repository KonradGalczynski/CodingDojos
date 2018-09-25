using System;
using System.Text;
using FizzBuzzSpecification;

namespace CodingDojos
{
    // requirements:
    // - write a program that prints to the console the numbers from 1 to N where N is supplied by user.
    // - for multiples of three print “Fizz” instead of the number
    // - for the multiples of five print “Buzz”
    // - for numbers which are multiples of both three and five print “FizzBuzz”
    public class MultiFizzBuzzer
    {
        private readonly ISingleFizzBuzzer _singleFizzBuzz;

        MultiFizzBuzzer(ISingleFizzBuzzer singleFizzBuzz)
        {

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("FizzBuzz main");
            Console.ReadKey();
        }



        public static string FizzBuzz(int n)
        {
            var singleFizzBuzz = new SingleFizzBuzzer();
            var fizzBuzz = new MultiFizzBuzzer(singleFizzBuzz);
            
            var result = new StringBuilder();
            for (var i = 1; i <= n; i++)
            {
                result.Append(singleFizzBuzz.Calc(i));
            }
            return result.ToString();
        }
    }
}
