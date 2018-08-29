namespace TennisSimplified
{
    public class Player1WonState : ITennisMatchState
    {
        public string GetResult()
        {
            return "Won -    ";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
        }
    }
}