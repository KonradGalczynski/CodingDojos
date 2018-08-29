namespace TennisSimplified
{
    public class LoveLoveState : ITennisMatchState
    {
        private readonly ITennisMatchStateFactory _tennisMatchStateFactory;

        public LoveLoveState(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _tennisMatchStateFactory = tennisMatchStateFactory;
        }

        public string GetResult()
        {
            return "  0 -   0";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreateNormalScoringState());
            tennisMatchCalculator.GetCurrentState().OnFirstPlayerWonBall(tennisMatchCalculator);
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreateNormalScoringState());
            tennisMatchCalculator.GetCurrentState().OnSecondPlayerWonBall(tennisMatchCalculator);
        }
    }
}