using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private string _player1Name;
        private string _player2Name;

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


        public string GetScore()
        {
            if (_player1Score == _player2Score)
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
            var player1ScoreDescription = ScoreHelper.ScoreDescription(_player1Score);
            var player2ScoreDescription = ScoreHelper.ScoreDescription(_player2Score);

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
                var scoreDescription = ScoreHelper.ScoreDescription(_player1Score);
                return $"{scoreDescription}-All";
            }
            else
            {
                return "Deuce";
            }
        }
    }
}

