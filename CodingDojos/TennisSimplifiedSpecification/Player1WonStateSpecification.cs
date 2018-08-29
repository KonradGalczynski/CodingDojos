using FluentAssertions;
using NSubstitute;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class Player1WonStateSpecification
    {
        [Fact]
        public void ShouldReturnPlayer1WonResultAfterCreation()
        {
            var player1WonState = new Player1WonState();

            player1WonState.GetResult().Should().Be("Won -    ");
        }

        [Fact]
        public void ShouldDoNothingWhenPlayer1WonBall()
        {
            var player1WonState = new Player1WonState();
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player1WonState.OnFirstPlayerWonBall(context);
            
            player1WonState.GetResult().Should().Be("Won -    ");
            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
        }

        [Fact]
        public void ShouldDoNothingWhenPlayer2WonBall()
        {
            var player1WonState = new Player1WonState();
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player1WonState.OnSecondPlayerWonBall(context);


            player1WonState.GetResult().Should().Be("Won -    ");
            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
        }
    }
}