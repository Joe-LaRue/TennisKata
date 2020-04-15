using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private string _player1Name;
        private string _player2Name;

        private string GetScoreDescription(int score)
        {
            var scoreDescriptions = new Dictionary<int, string>()
            {
                {0, "Love" },
                {1, "Fifteen" },
                {2, "Thirty" },
                {3,"Forty" }
            };

            return scoreDescriptions[score];
        }

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        private bool ScoreIsTied()
        {
            return _player1Score == _player2Score;
        }

        public string GetScore()
        {
            if (ScoreIsTied())
            {
                return GetTieScoreDescription();
            }

            if (_player1Score >= 4 || _player2Score >= 4)
            {
                return Get4OrMoreScoreDescription();
            }

            return GetLessThan4ScoreDescription();
        }

        private string GetLessThan4ScoreDescription()
        {
            var player1ScoreDescription = GetScoreDescription(_player1Score);
            var player2ScoreDescription = GetScoreDescription(_player2Score);
            return $"{player1ScoreDescription}-{player2ScoreDescription}";
        }

        private string Get4OrMoreScoreDescription()
        {
            var scoreDifference = _player1Score - _player2Score;


            if (scoreDifference == 1)
            {
                return "Advantage player1";
            }
            else if (scoreDifference == -1)
            {
                return "Advantage player2";
            }
            else if (scoreDifference >= 2)
            {
                return "Win for player1";
            }
            else
            {
                return "Win for player2";
            }
        }

        private string GetTieScoreDescription()
        {
            if (_player1Score < 3)
            {
                var scoreDescription = GetScoreDescription(_player1Score);
                return $"{scoreDescription}-All";
            }
            else
            {
                return "Deuce";
            }
        }
    }
}

