using FluentAssertions;
using Xunit;

namespace BankOcrSpecification
{
    public class DummySpecification
    {
        [Fact]
        public void DummySpecificationWithAssert()
        {
            const int a = 2;
            const int b = 3;
            const int expected = 5;

            const int sum = a + b;

            sum.Should().Be(expected);
        }
    }
}