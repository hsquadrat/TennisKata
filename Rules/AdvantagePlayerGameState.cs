namespace TennisKata;

public class AdvantagePlayerGameState : State
{
    public AdvantagePlayerGameState(Player player1, Player player2) : base(player1, player2)
    {
    }
    public override string getScore()
    {
        return player1.GetSpielstandzähler() > player2.GetSpielstandzähler() ? "Advantage Player1" : "Advantage Player 2";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {
        if (player1.Equals(playerWithPoint))
        {
            return new WinPlayerGameState(player1,player2);
        }
        else
        {
            return new DeuceGameState(player1,player2);
        }
    }
}