namespace TennisSimplified
{
    public class Player1AdvantageState : ITennisMatchState
    {
        private readonly ITennisMatchStateFactory _tennisMatchStateFactory;

        public Player1AdvantageState(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _tennisMatchStateFactory = tennisMatchStateFactory;
        }

        public string GetResult()
        {
            return "Adv -    ";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreatePlayer1WonState());
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreateDeuceState());
        }
    }
}
