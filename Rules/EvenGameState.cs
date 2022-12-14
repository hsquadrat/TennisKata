namespace TennisKata;

public class EvenGameState : State
{
    public EvenGameState(Player player1, Player player2) : base(player1, player2)
    {
    }

    public override string getScore()
    {
        return player1.GetSpielstandz√§hler() + "-All";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {

        if (playerWithPoint.GetSpielstandz√§hler() == GameCounter.Forty) {
            return new AdvantagePlayerGameState(player1,player2);
        }

        return new UnEvenGameState(player1, player2);
    }
}