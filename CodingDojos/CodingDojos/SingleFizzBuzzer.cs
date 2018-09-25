using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzSpecification
{
    public interface ISingleFizzBuzzer
    {
        string Calc(int n);
    }
    public class SingleFizzBuzzer: ISingleFizzBuzzer
    {
        public string Calc(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (n % 3 == 0)
            {
                return "Fizz";
            }

            if (n % 5 == 0)
            {
                return "Buzz";
            }

            return n.ToString();
        }
    }
}
