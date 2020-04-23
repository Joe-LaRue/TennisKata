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
            if (ScoreIsTied())
            {
                return GetTieScoreDescription();
            }

            if (BothPlayersHaveLessThan4Points())
            {
                var player1ScoreDescription = ScoreHelper.ScoreDescription(_player1Point);
                var player2ScoreDescription = ScoreHelper.ScoreDescription(_player2Point);

                return $"{player1ScoreDescription}-{player2ScoreDescription}";
            }

            if (Player1Leads())
            {
                return GetPlayer1LeadingScore();
            }
            else
            {
                return GetPlayer2LeadingScore();
            }
        }

        private bool Player1Leads()
        {
            return _player1Point > _player2Point;
        }

        private string GetPlayer1LeadingScore()
        {
            var scoreDifference = _player1Point - _player2Point;

            if (scoreDifference >= 2)
            {
                return "Win for player1";
            }

            return "Advantage player1";
        }

        private string GetPlayer2LeadingScore()
        {
            var scoreDifference = _player2Point - _player1Point;

            if (scoreDifference >= 2)
            {
                return "Win for player2";
            }

            return "Advantage player2";
        }

        private bool BothPlayersHaveLessThan4Points()
        {
            return _player1Point < 4 && _player2Point < 4;
        }

        private string GetTieScoreDescription()
        {
            if (_player1Point > 2)
            {
                return "Deuce";
            }

            var scoreDescription = ScoreHelper.ScoreDescription(_player1Point);
            return $"{scoreDescription}-All";
        }

        private bool ScoreIsTied()
        {
            return _player1Point == _player2Point;
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

