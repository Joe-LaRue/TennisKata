using System.Collections.Generic;

namespace Tennis
{
    public class ScoreHelper
    {
        private static Dictionary<int, string> _scoreDescriptions = new Dictionary<int, string>()
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3,"Forty" }
        };

        public static string ScoreDescription(int score)
        {
            return _scoreDescriptions[score];
        }
    }
}