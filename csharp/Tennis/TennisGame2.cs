using NUnit.Framework.Constraints;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
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
                var player1ScoreDescription = GetScoreDescription(p1point);
                var player2ScoreDescription = GetScoreDescription(p2point);

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
            return p1point > p2point;
        }

        private bool BothPlayersHaveLessThan4Points()
        {
            return p1point < 4 && p2point < 4 ;
        }

        private string GetTieScoreDescription()
        {
            if (p1point > 2)
            {
                return "Deuce";
            }

            var scoreDescription = GetScoreDescription(p1point);
            return $"{scoreDescription}-All";
        }

        private bool ScoreIsTied()
        {
            return p1point == p2point;
        }

        private bool Player1HasWon()
        {
            var scoreDifference = p1point - p2point;
            return p1point >= 4 &&
                p2point >= 0 &&
                scoreDifference >= 2;
        }

        private bool Player2HasWon()
        {
            var scoreDifference = p2point - p1point;
            return p2point >= 4 &&
                p1point >= 0 &&
                scoreDifference >= 2;
        }

        private bool Player1HasAdvantage()
        {
            return p1point > p2point && p2point >= 3;
        }

        private bool Player2HasAdvantage()
        {
            return p2point > p1point && p1point >= 3;
        }


        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
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

