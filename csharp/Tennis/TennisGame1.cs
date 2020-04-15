using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private string _player1Name;
        private string _player2Name;

        private Dictionary<int, string> _scoreValues = new Dictionary<int, string>()
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3,"Forty" }
        };

        public TennisGame1(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
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
            string score = "";
            var tempScore = 0;


            for (var i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    tempScore = _player1Score;
                }
                else 
                { 
                    score += "-"; 
                    tempScore = _player2Score;                
                }

                score += _scoreValues[tempScore];             
            }

            return score;
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
                return $"{_scoreValues[_player1Score]}-All";
            }
            else
            {
                return "Deuce";
            }           
        }
    }
}

