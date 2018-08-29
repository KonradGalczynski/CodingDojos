using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class Player2AdvantageStateSpecification
    {
        [Fact]
        public void ShouldReturnPlayer2AdvantageResultAfterCreation()
        {
            var player2AdvantageState = new Player2AdvantageState(Any.InstanceOf<ITennisMatchStateFactory>());

            player2AdvantageState.GetResult().Should().Be("    - Adv");
        }

        [Fact]
        public void ShouldSetCurrentStateToDeuceWhenPlayer1WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var deuceState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreateDeuceState().Returns(deuceState);
            var player2AdvantageState = new Player2AdvantageState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player2AdvantageState.OnFirstPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateDeuceState();
            context.Received().SetCurrentState(deuceState);
        }

        [Fact]
        public void ShouldSetCurrentStateToPlayer2WonWhenPlayer2WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var player2WonState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreatePlayer2WonState().Returns(player2WonState);
            var player2AdvantageState = new Player2AdvantageState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player2AdvantageState.OnSecondPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreatePlayer2WonState();
            context.Received().SetCurrentState(player2WonState);
        }
    }
}