namespace TennisKata;

public class DeuceGameState : State
{
    public DeuceGameState(Player player1, Player player2) : base(player1, player2)
    {
    }

    public override string getScore()
    {
        return "Deuce";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {
        return new AdvantagePlayerGameState(player1,player2);
    }
}