using System.Collections.Generic;

namespace BankOcr
{
    public class BatchBatchBankAccountRecognizer : IBatchBankAccountRecognizer
    {
        private readonly IBankAccountRecognizer _bankAccountRecognizer;

        public BatchBatchBankAccountRecognizer(IBankAccountRecognizer bankAccountRecognizer)
        {
            _bankAccountRecognizer = bankAccountRecognizer;
        }

        public IEnumerable<string> Recognize(IReadOnlyCollection<IReadOnlyCollection<char[][]>> formattedInput)
        {
            var result = new List<string>();

            foreach (var entry in formattedInput)
            {
                result.Add(_bankAccountRecognizer.Recognize(entry));
            }
            
            return result;
        }
    }
}