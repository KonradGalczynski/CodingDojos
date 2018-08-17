using BankOcr;
using FluentAssertions;
using Xunit;

namespace BankOcrSpecification.UnitSpecification
{
    public class DigitRecognizerSpecification
    {
        [Fact]
        public void ShouldRecogniDigitsCorrectly()
        {
            var digitRecognizer = new DigitRecognizer();

            for (var i = 0; i < TestHelpers.Digits.DigitsDictionary.Keys.Count; i++)
            {
                var result = digitRecognizer.Recognize(TestHelpers.Digits.DigitsDictionary[i]);

                result.Should().Be(i.ToString().ToCharArray(0, 1)[0]);
            }
        }
    }
}
