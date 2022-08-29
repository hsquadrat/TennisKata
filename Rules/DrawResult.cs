namespace TennisKata;

public class DrawResultRule : Rules
{
    public override string getScore(SpielstandZähler scorePlayer1, SpielstandZähler scorePlayer2)
    {
        string score = string.Empty;

        switch (scorePlayer1)
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
        
        return score;
    }
}