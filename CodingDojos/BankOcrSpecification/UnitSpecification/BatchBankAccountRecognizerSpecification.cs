using System.Collections.Generic;
using System.Linq;
using BankOcr;
using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace BankOcrSpecification.UnitSpecification
{
    public class BatchBankAccountRecognizerSpecification
    {
        [Fact]
        public void ShouldCallBankAccountRecognizerCorrectNumberOfTimesAndCollectResults()
        {
            var bankAccountRecognizer = Substitute.For<IBankAccountRecognizer>();
            var input = Any.ReadOnlyList<IReadOnlyCollection<char[][]>>();
            bankAccountRecognizer.Recognize(Arg.Any<IReadOnlyCollection<char[][]>>()).Returns(Any.String());
            var batchBankAccountRecognizer = new BatchBatchBankAccountRecognizer(bankAccountRecognizer);

            var result = batchBankAccountRecognizer.Recognize(input);

            bankAccountRecognizer.Received(input.Count).Recognize(Arg.Any<IReadOnlyCollection<char[][]>>());
            result.Count().Should().Be(input.Count);
        }
    }
}