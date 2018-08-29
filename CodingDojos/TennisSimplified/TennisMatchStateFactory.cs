namespace TennisSimplified
{
    public class TennisMatchStateFactory : ITennisMatchStateFactory
    {
        public ITennisMatchState CreateLoveLoveState()
        {
            return new LoveLoveState(this);
        }

        public ITennisMatchState CreateNormalScoringState()
        {
            return new NormalScoringState(this);
        }

        public ITennisMatchState CreateDeuceState()
        {
            return new DeuceState(this);
        }

        public ITennisMatchState CreatePlayer1AdvantageState()
        {
            return new Player1AdvantageState(this);
        }

        public ITennisMatchState CreatePlayer2AdvantageState()
        {
            return new Player2AdvantageState(this);
        }

        public ITennisMatchState CreatePlayer1WonState()
        {
            return new Player1WonState();
        }

        public ITennisMatchState CreatePlayer2WonState()
        {
            return new Player2WonState();
        }
    }
}