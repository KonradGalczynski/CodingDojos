using System;

namespace TennisSimplified
{
    public class DeuceState : ITennisMatchState
    {
        private readonly ITennisMatchStateFactory _tennisMatchStateFactory;

        public DeuceState(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _tennisMatchStateFactory = tennisMatchStateFactory;
        }

        public string GetResult()
        {
            return "  Deuce  ";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreatePlayer1AdvantageState());
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreatePlayer2AdvantageState());
        }
    }
}