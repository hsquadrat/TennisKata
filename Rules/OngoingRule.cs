namespace TennisKata;
public class OngoingRule : Rules
{
    public override string getScore(SpielstandZähler scorePlayer1, SpielstandZähler scorePlayer2)
    {
        string score = string.Empty;
        return scorePlayer1 + "-" + scorePlayer2;
    }
}