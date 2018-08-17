using System.Collections.Generic;
using BankOcr;
using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using Xunit;

namespace BankOcrSpecification.UnitSpecification
{
    public class BankAccountRecognizerSpecification
    {
        [Fact]
        public void ShouldRecognizeEverySingleDigitAndAggregateResult()
        {
            var digitRecognizer = Substitute.For<IDigitRecognizer>();
            digitRecognizer.Recognize(Arg.Any<char[][]>()).Returns(Any.Char());
            var bankAccountRecognizer = new BankAccountRecognizer(digitRecognizer);
            IReadOnlyCollection<char[][]> digitsCollection = Any.ReadOnlyList<char[][]>();

            var result = bankAccountRecognizer.Recognize(digitsCollection);

            digitRecognizer.Received(digitsCollection.Count).Recognize(Arg.Any<char[][]>());
            result.Length.Should().Be(digitsCollection.Count);
        }
    }
}