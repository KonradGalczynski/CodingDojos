namespace TennisSimplified
{
    public class TennisMatchCalculator : ITennisMatchCalculator, ITennisMatchCalculatorContext
    {
        private ITennisMatchState _currentState;

        public TennisMatchCalculator(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _currentState = tennisMatchStateFactory.CreateLoveLoveState();
        }

        public string GetResult()
        {
            return _currentState.GetResult();
        }

        public void OnFirstPlayerWonBall()
        {
            _currentState.OnFirstPlayerWonBall(this);
        }

        public void OnSecondPlayerWonBall()
        {
            _currentState.OnSecondPlayerWonBall(this);
        }

        public void SetCurrentState(ITennisMatchState state)
        {
            _currentState = state;
        }

        public ITennisMatchState GetCurrentState()
        {
            return _currentState;
        }
    }
}