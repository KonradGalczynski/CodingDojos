using System.Collections.Generic;
using BankOcr;
using BankOcrSpecification.TestHelpers;
using FluentAssertions;
using TddEbook.TddToolkit;
using Xunit;

namespace BankOcrSpecification.UnitSpecification
{
    public class InputValidatorSpecification
    {
        private readonly IDictionary<InputType, IEnumerable<string>> _input =
            new Dictionary<InputType, IEnumerable<string>>
            {
                {InputType.NullInput, null},
                {InputType.EmptyInput, new List<string>()},
                {InputType.NonemptyInput, new List<string> {Any.String(), Any.String()}}
            };

        [Theory]
        [InlineData(InputType.NullInput)]
        [InlineData(InputType.EmptyInput)]
        [InlineData(InputType.NonemptyInput)]
        public void ShouldValidatePositivelyAllInputs(InputType inputType)
        {
            var validator = new InputValidator();

            var result = validator.IsValid(_input[inputType]);

            result.Should().BeTrue();
        }
    }
}