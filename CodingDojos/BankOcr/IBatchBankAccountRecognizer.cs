using System.Collections.Generic;

namespace BankOcr
{
    public interface IBatchBankAccountRecognizer
    {
        IEnumerable<string> Recognize(IReadOnlyCollection<IReadOnlyCollection<char[][]>> formattedInput);
    }
}