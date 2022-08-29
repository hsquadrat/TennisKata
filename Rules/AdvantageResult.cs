namespace TennisKata;
public class AdvantageResult:Rules
{
    public override string getScore(SpielstandZähler scorePlayer1, SpielstandZähler scorePlayer2)
    {
        string score = string.Empty;
        
        var minusResult = scorePlayer1 - scorePlayer2;
        if (minusResult == 1) score = "Advantage player1";
        else if (minusResult == -1) score = "Advantage player2";
        else if (minusResult >= 2) score = "Win for player1";
        else score = "Win for player2";

        return score;
    }
}