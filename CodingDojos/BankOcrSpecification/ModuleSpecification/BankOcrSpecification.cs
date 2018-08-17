using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BankOcr;
using FluentAssertions;
using Xunit;

namespace BankOcrSpecification.ModuleSpecification
{
    public class BankOcrSpecification
    {
        public IEnumerable<string> ReadLines(Func<Stream> streamProvider,
            Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null) yield return line;
            }
        }

        [Fact]
        public void ShouldRecognizeInputWithtenEntriesWithAllDigits()
        {
            var expectedAccountNumbers = new List<string>
            {
                "000000000", "111111111", "222222222", "333333333", "444444444",
                "555555555", "666666666", "777777777", "888888888", "999999999",
                "123456789"
            };
            var inputValidator = new InputValidator();
            var inputFormatter = new InputFormatter();
            var digitRecognizer = new DigitRecognizer();
            var bankAccountRecognizer = new BankAccountRecognizer(digitRecognizer);
            var batchBankAccountRecognizer = new BatchBatchBankAccountRecognizer(bankAccountRecognizer);

            var input = ReadLines(() => Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream("BankOcrSpecification.TestHelpers.input.txt"),
                    Encoding.UTF8)
                .ToList();

            if (inputValidator.IsValid(input))
            {
                var formattedInput = inputFormatter.Format(input);
                var bankAccountNumbers = batchBankAccountRecognizer.Recognize(formattedInput);

                bankAccountNumbers.Should().BeEquivalentTo(expectedAccountNumbers);
            }
        }
    }
}