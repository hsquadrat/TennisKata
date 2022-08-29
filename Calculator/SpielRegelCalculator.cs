namespace TennisKata;

public class SpielRegelCalculator : ISpielregelCalculator
{
    public string Calculate(Player player1, Player player2)
    {
        var score1 = player1.GetSpielstandzähler();
        var score2 = player2.GetSpielstandzähler();

        
        if (score1.Equals(score2))
        {
            return new DrawResultRule().getScore(score1,score2);
            
        }else if (score1 >= SpielstandZähler.Fourty || score2 >= SpielstandZähler.Fourty)
        {
            return new AdvantageResult().getScore(score1,score2);
        }
        else
        {
            return new OngoingRule().getScore(score1, score2);
        }
    }
}