using NUnit.Framework.Constraints;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Point;
        private int _player2Point;

        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            _player1Point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (ScoreIsTied())
            {
                return GetTieScoreDescription();
            }

            if (BothPlayersHaveLessThan4Points())
            {
                var player1ScoreDescription = GetScoreDescription(_player1Point);
                var player2ScoreDescription = GetScoreDescription(_player2Point);

                return $"{player1ScoreDescription}-{player2ScoreDescription}";
            }
           
            if (Player1HasAdvantage())
            {
                score = "Advantage player1";
            }

            if (Player2HasAdvantage())
            {
                score = "Advantage player2";
            }

            if (Player1HasWon())
            {
                score = "Win for player1";
            }
            if (Player2HasWon())
            {
                score = "Win for player2";
            }
            return score;
        }

        private string GetScoreDescription(int score)
        {
            var scoreDescriptions = new Dictionary<int, string>()
            {
                {0, "Love" },
                {1, "Fifteen" },
                {2, "Thirty" },
                {3, "Forty" }
            };

            return scoreDescriptions[score];
        }


        private bool Player1Leads()
        {
            return _player1Point > _player2Point;
        }

        private bool BothPlayersHaveLessThan4Points()
        {
            return _player1Point < 4 && _player2Point < 4 ;
        }

        private string GetTieScoreDescription()
        {
            if (_player1Point > 2)
            {
                return "Deuce";
            }

            var scoreDescription = GetScoreDescription(_player1Point);
            return $"{scoreDescription}-All";
        }

        private bool ScoreIsTied()
        {
            return _player1Point == _player2Point;
        }

        private bool Player1HasWon()
        {
            var scoreDifference = _player1Point - _player2Point;
            return _player1Point >= 4 &&
                _player2Point >= 0 &&
                scoreDifference >= 2;
        }

        private bool Player2HasWon()
        {
            var scoreDifference = _player2Point - _player1Point;
            return _player2Point >= 4 &&
                _player1Point >= 0 &&
                scoreDifference >= 2;
        }

        private bool Player1HasAdvantage()
        {
            return _player1Point > _player2Point && _player2Point >= 3;
        }

        private bool Player2HasAdvantage()
        {
            return _player2Point > _player1Point && _player1Point >= 3;
        }


        private void P1Score()
        {
            _player1Point++;
        }

        private void P2Score()
        {
            _player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

