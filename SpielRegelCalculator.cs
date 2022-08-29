namespace TennisKata;

public class SpielRegelCalculator : ISpielregelCalculator
{
    private string score = "";
    private SpielstandZähler score1 = 0;
    private SpielstandZähler score2 = 0;
    private SpielstandZähler tempScore = 0;

    public string Calculate(Player player1, Player player2)
    {
        score1 = player1.GetSpielstandzähler();
        score2 = player2.GetSpielstandzähler();

        if (score1.Equals(score2))
        {
            switch (score1)
            {
                case SpielstandZähler.Love:
                    score = "Love-All";
                    break;
                case SpielstandZähler.Fifteen:
                    score = "Fifteen-All";
                    break;
                case SpielstandZähler.Thirty:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }
        }
        else if (score1 >= SpielstandZähler.Fourty || score2 >= SpielstandZähler.Fourty)
        {
            var minusResult = score1 - score2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
        }
        else
        {
            for (var i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    tempScore = score1;
                }
                else
                {
                    score += "-";
                    tempScore = score2;
                }

                switch (tempScore)
                {
                    case SpielstandZähler.Love:
                        score += "Love";
                        break;
                    case SpielstandZähler.Fifteen:
                        score += "Fifteen";
                        break;
                    case SpielstandZähler.Thirty:
                        score += "Thirty";
                        break;
                    case SpielstandZähler.Fourty:
                        score += "Forty";
                        break;
                }
            }
        }

        return score;
    }
}