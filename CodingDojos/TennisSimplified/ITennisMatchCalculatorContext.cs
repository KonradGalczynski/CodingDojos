namespace TennisSimplified
{
    public interface ITennisMatchCalculatorContext
    {
        void SetCurrentState(ITennisMatchState state);
        ITennisMatchState GetCurrentState();
    }
}