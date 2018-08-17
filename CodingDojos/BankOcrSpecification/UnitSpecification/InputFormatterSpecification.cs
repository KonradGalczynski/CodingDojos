using System;
using System.Collections.Generic;
using System.Linq;
using BankOcr;
using BankOcrSpecification.TestHelpers;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace BankOcrSpecification.UnitSpecification
{
    public class InputFormatterSpecification
    {
        private readonly IDictionary<InputType, IEnumerable<string>> _input =
            new Dictionary<InputType, IEnumerable<string>>
            {
                {InputType.NullInput, null},
                {InputType.EmptyInput, new List<string>()}
            };

        [Theory]
        [InlineData(InputType.NullInput)]
        [InlineData(InputType.EmptyInput)]
        public void ShouldReturnEmptyResultWhenInputIs(InputType inputType)
        {
            var inputFormatter = new InputFormatter();

            var result = inputFormatter.Format(_input[inputType]);

            result.Count.Should().Be(0);
        }

        [Fact]
        public void ShouldFormatValidOneSegmentOfInputData()
        {
            const int inputLineLength = 27;
            const int digitsInLine = 9;
            var inputFormatter = new InputFormatter();

            var line1 = Any.StringOfLength(inputLineLength);
            var line2 = Any.StringOfLength(inputLineLength);
            var line3 = Any.StringOfLength(inputLineLength);
            IEnumerable<string> input = new List<string>
            {
                line1,
                line2,
                line3,
                string.Empty
            };
            var result = inputFormatter.Format(input);

            result.Count.Should().Be(1);
            result.First().Count.Should().Be(digitsInLine);
            var digits = result.First().ToArray();
            for (var i = 0; i < digitsInLine; i++)
            {
                digits[i][0][0].Should().Be(Convert.ToChar(line1.Substring(3 * i, 1)));
                digits[i][0][1].Should().Be(Convert.ToChar(line1.Substring(3 * i + 1, 1)));
                digits[i][0][2].Should().Be(Convert.ToChar(line1.Substring(3 * i + 2, 1)));
                digits[i][1][0].Should().Be(Convert.ToChar(line2.Substring(3 * i, 1)));
                digits[i][1][1].Should().Be(Convert.ToChar(line2.Substring(3 * i + 1, 1)));
                digits[i][1][2].Should().Be(Convert.ToChar(line2.Substring(3 * i + 2, 1)));
                digits[i][2][0].Should().Be(Convert.ToChar(line3.Substring(3 * i, 1)));
                digits[i][2][1].Should().Be(Convert.ToChar(line3.Substring(3 * i + 1, 1)));
                digits[i][2][2].Should().Be(Convert.ToChar(line3.Substring(3 * i + 2, 1)));
            }
        }

        [Fact]
        public void ShouldFormatValidTwoSegmentsOfInputData()
        {
            const int inputLineLength = 27;
            const int digitsInLine = 9;
            var inputFormatter = new InputFormatter();
            const int expectedEntriesNumber = 2;

            var line1 = Any.StringOfLength(inputLineLength);
            var line2 = Any.StringOfLength(inputLineLength);
            var line3 = Any.StringOfLength(inputLineLength);
            var line4 = Any.StringOfLength(inputLineLength);
            var line5 = Any.StringOfLength(inputLineLength);
            var line6 = Any.StringOfLength(inputLineLength);
            IEnumerable<string> input = new List<string>
            {
                line1,
                line2,
                line3,
                string.Empty,
                line4,
                line5,
                line6,
                string.Empty
            };
            var result = inputFormatter.Format(input);

            result.Count.Should().Be(expectedEntriesNumber);
            var firstEntry = result.ToArray()[0].ToArray();
            for (var j = 0; j < digitsInLine; j++)
            {
                firstEntry[j][0][0].Should().Be(Convert.ToChar(line1.Substring(3 * j, 1)));
                firstEntry[j][0][1].Should().Be(Convert.ToChar(line1.Substring(3 * j + 1, 1)));
                firstEntry[j][0][2].Should().Be(Convert.ToChar(line1.Substring(3 * j + 2, 1)));
                firstEntry[j][1][0].Should().Be(Convert.ToChar(line2.Substring(3 * j, 1)));
                firstEntry[j][1][1].Should().Be(Convert.ToChar(line2.Substring(3 * j + 1, 1)));
                firstEntry[j][1][2].Should().Be(Convert.ToChar(line2.Substring(3 * j + 2, 1)));
                firstEntry[j][2][0].Should().Be(Convert.ToChar(line3.Substring(3 * j, 1)));
                firstEntry[j][2][1].Should().Be(Convert.ToChar(line3.Substring(3 * j + 1, 1)));
                firstEntry[j][2][2].Should().Be(Convert.ToChar(line3.Substring(3 * j + 2, 1)));
            }
            var secondEntry = result.ToArray()[1].ToArray();
            for (var j = 0; j < digitsInLine; j++)
            {
                secondEntry[j][0][0].Should().Be(Convert.ToChar(line4.Substring(3 * j, 1)));
                secondEntry[j][0][1].Should().Be(Convert.ToChar(line4.Substring(3 * j + 1, 1)));
                secondEntry[j][0][2].Should().Be(Convert.ToChar(line4.Substring(3 * j + 2, 1)));
                secondEntry[j][1][0].Should().Be(Convert.ToChar(line5.Substring(3 * j, 1)));
                secondEntry[j][1][1].Should().Be(Convert.ToChar(line5.Substring(3 * j + 1, 1)));
                secondEntry[j][1][2].Should().Be(Convert.ToChar(line5.Substring(3 * j + 2, 1)));
                secondEntry[j][2][0].Should().Be(Convert.ToChar(line6.Substring(3 * j, 1)));
                secondEntry[j][2][1].Should().Be(Convert.ToChar(line6.Substring(3 * j + 1, 1)));
                secondEntry[j][2][2].Should().Be(Convert.ToChar(line6.Substring(3 * j + 2, 1)));
            }
        }
    }
}