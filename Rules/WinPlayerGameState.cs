namespace TennisKata;

public class WinPlayerGameState : State
{
    public WinPlayerGameState(Player player1, Player player2) : base(player1, player2)
    {
    }

    public override string getScore()
    {
        return player1.GetSpielstandzähler() > player2.GetSpielstandzähler() ? "Win Player1" : "Win Player 2";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {
        return null;
    }
}