using System;
using System.Collections.Generic;
using System.IO;

namespace BankOcr
{
    internal class FileReader : IFileReader
    {
        public IReadOnlyList<string> Read(string file)
        {
            return File.ReadAllLines(file);
        }
    }
}