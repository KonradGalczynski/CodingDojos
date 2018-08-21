using System.Collections.Generic;
using BankOcr;
using BankOcrSpecification.TestHelpers;
using FluentAssertions;
using Xunit;

namespace BankOcrSpecification
{
    public class BankOcrSpecification
    {
        [Theory]
        [InlineData(UseCases.GivenZeros, UseCases.ExpectedZeros)]
        [InlineData(UseCases.GivenOnes, UseCases.ExpectedOnes)]
        [InlineData(UseCases.GivenTwos, UseCases.ExpectedTwos)]
        [InlineData(UseCases.GivenThrees, UseCases.ExpectedThrees)]
        [InlineData(UseCases.GivenFours, UseCases.ExpectedFours)]
        [InlineData(UseCases.GivenFives, UseCases.ExpectedFives)]
        [InlineData(UseCases.GivenSixes, UseCases.ExpectedSixes)]
        [InlineData(UseCases.GivenSevens, UseCases.ExpectedSevens)]
        [InlineData(UseCases.GivenEights, UseCases.ExpectedEights)]
        [InlineData(UseCases.GivenNines, UseCases.ExpectedNines)]
        [InlineData(UseCases.GivenFullHouse, UseCases.ExpectedFullHouse)]
        [InlineData(UseCases.GivenJoker, UseCases.ExpectedQuestionMark)]

        public void GiveXReturnsX(string given, string expected)
        {
            var decoder = new OcrDecoder(new List<Template>
            {
                Template.Zero(),
                Template.One(),
                Template.Two(),
                Template.Three(),
                Template.Four(),
                Template.Five(),
                Template.Six(),
                Template.Seven(),
                Template.Eight(),
                Template.Nine(),
                Template.Joker()
            });
            decoder.DecodeLine(given).Should().Be(expected);
        }
    }
}