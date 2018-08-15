using System.Collections.Generic;

namespace BankOcr
{
    internal interface IInputFormatter
    {
        IReadOnlyCollection<IReadOnlyCollection<char[][]>> Format(IEnumerable<string> input);
    }
}