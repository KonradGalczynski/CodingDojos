using FluentAssertions;
using NSubstitute;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class Player2WonStateSpecification
    {
        [Fact]
        public void ShouldReturnPlayer2WonResultAfterCreation()
        {
            var player2WonState = new Player2WonState();

            player2WonState.GetResult().Should().Be("    - Won");
        }

        [Fact]
        public void ShouldDoNothingWhenPlayer1WonBall()
        {
            var player2WonState = new Player2WonState();
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player2WonState.OnFirstPlayerWonBall(context);

            player2WonState.GetResult().Should().Be("    - Won");
            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
        }

        [Fact]
        public void ShouldDoNothingWhenPlayer2WonBall()
        {
            var player2WonState = new Player2WonState();
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player2WonState.OnSecondPlayerWonBall(context);

            player2WonState.GetResult().Should().Be("    - Won");
            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
        }
    }
}