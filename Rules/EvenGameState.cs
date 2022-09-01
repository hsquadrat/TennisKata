namespace TennisKata;

public class EvenGameState : State
{
    public EvenGameState(Player player1, Player player2) : base(player1, player2)
    {
    }

    public override string getScore()
    {
        return player1.GetSpielstandzähler() + "-All";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {

        if (playerWithPoint.GetSpielstandzähler() == GameCounter.Forty) {
            return new AdvantagePlayerGameState(player1,player2);
        }

        return new UnEvenGameState(player1, player2);
    }
}