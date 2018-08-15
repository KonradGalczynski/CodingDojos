using System;
using System.Collections.Generic;

namespace BankOcr
{
    public class InputValidator : IInputValidator
    {
        public bool IsValid(IEnumerable<string> input)
        {
            return true;
        }
    }
}