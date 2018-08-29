using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class DeuceStateSpecification
    {
        [Fact]
        public void ShouldReturnDeuceResultAfterCreation()
        {
            var deuceState = new DeuceState(Any.InstanceOf<ITennisMatchStateFactory>());

            deuceState.GetResult().Should().Be("  Deuce  ");
        }

        [Fact]
        public void ShouldSetCurrentStateToPlayer1AdvantageStateWhenPlayer1WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var player1AdvantageState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreatePlayer1AdvantageState().Returns(player1AdvantageState);
            var deuceState = new DeuceState(tennisMatchStateFactory);

            var context = Substitute.For<ITennisMatchCalculatorContext>();
            deuceState.OnFirstPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreatePlayer1AdvantageState();
            context.Received().SetCurrentState(player1AdvantageState);
        }

        [Fact]
        public void ShouldSetCurrentStateToPlayer2AdvantageStateWhenPlayer2WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var player2AdvantageState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreatePlayer2AdvantageState().Returns(player2AdvantageState);
            var deuceState = new DeuceState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            deuceState.OnSecondPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreatePlayer2AdvantageState();
            context.Received().SetCurrentState(player2AdvantageState);
        }
    }
}