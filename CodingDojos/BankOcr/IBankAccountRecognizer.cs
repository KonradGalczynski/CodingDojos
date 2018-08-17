using System.Collections.Generic;

namespace BankOcr
{
    public interface IBankAccountRecognizer
    {
        string Recognize(IReadOnlyCollection<char[][]> entry);
    }
}