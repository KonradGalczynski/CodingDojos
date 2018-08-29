namespace TennisSimplified
{
    public interface ITennisMatchStateFactory
    {
        ITennisMatchState CreateLoveLoveState();
        ITennisMatchState CreateNormalScoringState();
        ITennisMatchState CreateDeuceState();
        ITennisMatchState CreatePlayer1AdvantageState();
        ITennisMatchState CreatePlayer2AdvantageState();
        ITennisMatchState CreatePlayer1WonState();
        ITennisMatchState CreatePlayer2WonState();
    }
}