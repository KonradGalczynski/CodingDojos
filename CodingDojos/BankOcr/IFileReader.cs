using System.Collections.Generic;

namespace BankOcr
{
    internal interface IFileReader
    {
        IReadOnlyList<string> Read(string file);
    }
}