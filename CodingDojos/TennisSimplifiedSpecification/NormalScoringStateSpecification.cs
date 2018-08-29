using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class NormalScoringStateSpecification
    {
        [Fact]
        public void ShouldReturnLoveLoveResultWhenScoringStateWasCreated()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());

            normalScoringState.GetResult().Should().Be("  0 -   0");
        }

        [Fact]
        public void ShouldReturnFifteenLoveResultWhenPlayer1WonBall()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 15 -   0");
        }

        [Fact]
        public void ShouldReturnThirtyLoveResultWhenPlayer1WonTwoBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 30 -   0");
        }

        [Fact]
        public void ShouldReturnFortyLoveResultWhenPlayer1WonThreeBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 40 -   0");
        }

        [Fact]
        public void ShouldReturnLoveFifteenResultWhenPlayer2WonBall()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be("  0 -  15");
        }

        [Fact]
        public void ShouldReturnLoveThirtyResultWhenPlayer2WonTwoBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be("  0 -  30");
        }

        [Fact]
        public void ShouldReturnLoveFortyResultWhenPlayer2WonThreeBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be("  0 -  40");
        }

        [Fact]
        public void ShouldReturnFifteenFifteenResultWhenBothPlayersWonBall()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 15 -  15");
        }

        [Fact]
        public void ShouldReturnThirtyThirtyResultWhenBothPlayersWonTwoBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 30 -  30");
        }

        [Fact]
        public void ShouldReturnThirtyFifteenResultWhenPlayer1WonTwoBallsAndPlayer2WonOneBall()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 30 -  15");
        }

        [Fact]
        public void ShouldReturnFifteenThirtyResultWhenPlayer1WonOneBallAndPlayer2WonTwoBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 15 -  30");
        }

        [Fact]
        public void ShouldReturnFortyFifteenResultWhenPlayer1WonThreeBallsAndPlayer2WonOneBall()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 40 -  15");
        }

        [Fact]
        public void ShouldReturnFifteenFortyResultWhenPlayer1WonOneBallAndPlayer2WonThreeBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 15 -  40");
        }

        [Fact]
        public void ShouldReturnFortyThirtyResultWhenPlayer1WonThreeBallsAndPlayer2WonTwoBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 40 -  30");
        }

        [Fact]
        public void ShouldReturnThirtyFortyResultWhenPlayer1WonTwoBallsAndPlayer2WonThreeBalls()
        {
            var normalScoringState = new NormalScoringState(Any.InstanceOf<ITennisMatchStateFactory>());
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            context.DidNotReceive().SetCurrentState(Arg.Any<ITennisMatchState>());
            normalScoringState.GetResult().Should().Be(" 30 -  40");
        }

        [Fact]
        public void ShouldSetCurrentStateToDeuceWhenPlayer1WonThreeBallsPlayer2WonTwoBallsAndPlayer2WonOneBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var deuceState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreateDeuceState().Returns(deuceState);
            var normalScoringState = new NormalScoringState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);

            normalScoringState.OnSecondPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateDeuceState();
            context.Received().SetCurrentState(deuceState);
        }

        [Fact]
        public void ShouldSetCurrentStateToDeuceWhenPlayer1WonTwoBallsPlayer2WonThreeBallsAndPlayer1WonOneBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var deuceState = Any.InstanceOf<ITennisMatchState>();
            tennisMatchStateFactory.CreateDeuceState().Returns(deuceState);
            var normalScoringState = new NormalScoringState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();

            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnFirstPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);
            normalScoringState.OnSecondPlayerWonBall(context);

            normalScoringState.OnFirstPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateDeuceState();
            context.Received().SetCurrentState(deuceState);
        }
    }
}