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

            string score = "";
            var tempScore = 0;


            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = _player1Score;
                else { score += "-"; tempScore = _player2Score; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
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
            switch (_player1Score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";

            }
        }
    }
}

