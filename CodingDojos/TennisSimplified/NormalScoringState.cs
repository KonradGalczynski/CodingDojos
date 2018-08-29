using System.Collections.Generic;
using System.Globalization;

namespace TennisSimplified
{
    public class NormalScoringState : ITennisMatchState
    {
        private const string Player1Name = "Player1";
        private const string Player2Name = "Player2";

        private readonly Dictionary<int, string> _ballsWonToTennisPoints = new Dictionary<int, string>
        {
            {0, "0"},
            {1, "15"},
            {2, "30"},
            {3, "40"}
        };

        private readonly Dictionary<string, int> _setResult;

        private readonly ITennisMatchStateFactory _tennisMatchStateFactory;

        public NormalScoringState(ITennisMatchStateFactory tennisMatchStateFactory)
        {
            _tennisMatchStateFactory = tennisMatchStateFactory;
            _setResult = new Dictionary<string, int>
            {
                {Player1Name, 0},
                {Player2Name, 0}
            };
        }

        public string GetResult()
        {
            var player1Result = string.Format(CultureInfo.InvariantCulture, "{0,3:###}",
                _ballsWonToTennisPoints[_setResult[Player1Name]]);
            var player2Result = string.Format(CultureInfo.InvariantCulture, "{0,3:###}",
                _ballsWonToTennisPoints[_setResult[Player2Name]]);
            return $"{player1Result} - {player2Result}";
        }

        public void OnFirstPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            _setResult[Player1Name] += 1;

            if (GetResult() == " 40 -  40") GoToDeuceState(tennisMatchCalculator);
        }

        public void OnSecondPlayerWonBall(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            _setResult[Player2Name] += 1;

            if (GetResult() == " 40 -  40") GoToDeuceState(tennisMatchCalculator);
        }

        private void GoToDeuceState(ITennisMatchCalculatorContext tennisMatchCalculator)
        {
            tennisMatchCalculator.SetCurrentState(_tennisMatchStateFactory.CreateDeuceState());
        }
    }
}