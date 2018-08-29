namespace TennisSimplified
{
    public class Player2WonState : ITennisMatchState
    {
        public string GetResult()
        {
            return "    - Won";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
        }
    }
}