using System.Collections.Generic;
using System.Text;

namespace BankOcr
{
    public class BankAccountRecognizer : IBankAccountRecognizer
    {
        private readonly IDigitRecognizer _digitRecognizer;

        public BankAccountRecognizer(IDigitRecognizer digitRecognizer)
        {
            _digitRecognizer = digitRecognizer;
        }

        public string Recognize(IReadOnlyCollection<char[][]> entry)
        {
            var sb = new StringBuilder();

            foreach (var digit in entry)
            {
                sb.Append(_digitRecognizer.Recognize(digit));
            }

            return sb.ToString();
        }
    }
}