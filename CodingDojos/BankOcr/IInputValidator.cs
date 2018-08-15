using System.Collections.Generic;

namespace BankOcr
{
    internal interface IInputValidator
    {
        bool IsValid(IEnumerable<string> input);
    }
}