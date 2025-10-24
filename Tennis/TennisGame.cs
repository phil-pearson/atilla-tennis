namespace Tennis
{
    public class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (m_score1 == m_score2)
            {
                return EqualScoreToString(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                return AdvantageScoreToString(minusResult);
            }
            else
            {
                score = ScoreToString(m_score1) + "-";
                score += ScoreToString(m_score2);
            }
            return score;
        }

        string ScoreToString(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }

        string EqualScoreToString(int score)
        {
            return score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        string AdvantageScoreToString(int scoreDifference)
        {
            return scoreDifference switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                _ when scoreDifference >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }
    }
}

