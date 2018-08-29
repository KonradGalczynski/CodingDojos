using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class Player1AdvantageStateSpecification
    {
        [Fact]
        public void ShouldReturnPlayer1AdvantageResultAfterCreation()
        {
            var player1AdvantageState = new Player1AdvantageState(Any.InstanceOf<ITennisMatchStateFactory>());

            player1AdvantageState.GetResult().Should().Be("Adv -    ");
        }

        [Fact]
        public void ShouldSetCurrentStateToDeuceWhenPlayer2WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var deuceState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreateDeuceState().Returns(deuceState);
            var player1AdvantageState = new Player1AdvantageState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player1AdvantageState.OnSecondPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateDeuceState();
            context.Received().SetCurrentState(deuceState);
        }

        [Fact]
        public void ShouldSetCurrentStateToPlayer1WonWhenPlayer1WonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var player1WonState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreatePlayer1WonState().Returns(player1WonState);
            var player1AdvantageState = new Player1AdvantageState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            player1AdvantageState.OnFirstPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreatePlayer1WonState();
            context.Received().SetCurrentState(player1WonState);
        }
    }
}