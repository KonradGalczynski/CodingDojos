namespace TennisSimplified
{
    public interface ITennisMatchState
    {
        string GetResult();
        void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator);
        void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator);
    }
}