namespace TennisSimplified
{
    public interface ITennisMatchCalculator
    {
        string GetResult();
        void OnFirstPlayerWonBall();
        void OnSecondPlayerWonBall();
    }
}