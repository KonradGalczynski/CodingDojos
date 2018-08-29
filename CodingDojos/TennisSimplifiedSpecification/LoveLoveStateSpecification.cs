using FluentAssertions;
using NSubstitute;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class LoveLoveStateSpecification
    {
        [Fact]
        public void ShouldReturnLoveLoveResultWhenGetResultCalled()
        {
            var loveLoveState = new LoveLoveState(Any.InstanceOf<ITennisMatchStateFactory>());

            loveLoveState.GetResult().Should().Be("  0 -   0");
        }

        [Fact]
        public void ShouldSetCurrentStateToNormalScoringStateAndForwardOnBallWonOnFirstPlayerWonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var normalScoringState = Substitute.For<ITennisMatchState>();
            tennisMatchStateFactory.CreateNormalScoringState().Returns(normalScoringState);
            var loveLoveState = new LoveLoveState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();
            context.GetCurrentState().Returns(normalScoringState);

            loveLoveState.OnFirstPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateNormalScoringState();
            context.Received().SetCurrentState(normalScoringState);
            normalScoringState.Received().OnFirstPlayerWonBall(context);
        }


        [Fact]
        public void ShouldSetCurrentStateToNormalScoringStateAndForwardOnBallWonOnSecondPlayerWonBall()
        {
            var tennisMatchStateFactory = Substitute.For<ITennisMatchStateFactory>();
            var normalScoringState = Substitute.For<ITennisMatchState>();
            tennisMatchStateFactory.CreateNormalScoringState().Returns(normalScoringState);
            var loveLoveState = new LoveLoveState(tennisMatchStateFactory);
            var context = Substitute.For<ITennisMatchCalculatorContext>();
            context.GetCurrentState().Returns(normalScoringState);

            loveLoveState.OnSecondPlayerWonBall(context);

            tennisMatchStateFactory.Received().CreateNormalScoringState();
            context.Received().SetCurrentState(normalScoringState);
            normalScoringState.Received().OnSecondPlayerWonBall(context);
        }
    }
}