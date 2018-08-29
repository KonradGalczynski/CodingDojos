namespace TennisSimplified
{
    public class Player2AdvantageState : ITennisMatchState
    {
        private readonly ITennisMatchStateFactory _tennisMatchStateFactory;

        public Player2AdvantageState(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _tennisMatchStateFactory = tennisMatchStateFactory;
        }

        public string GetResult()
        {
            return "    - Adv";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreateDeuceState());
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreatePlayer2WonState());
        }
    }
}