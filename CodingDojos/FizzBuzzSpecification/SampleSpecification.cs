namespace FizzBuzzSpecification
{
	using FluentAssertions;
	using TddEbook.TddToolkit;
	using Xunit;

	public class SampleSpecification
	{
		[Fact]
		public void Specification()
		{
			var a = Any.Integer();
			var b = Any.Integer();

			var expectedSum = a + b;

			expectedSum.Should().Be(a + b);
		}
	}
}
