namespace TennisKata;

public class InitialState : State
{
    public InitialState(Player player1, Player player2) : base(player1, player2)
    {
    }
    
    public override string getScore()
    {
        return "Love-All";
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {
        return new UnEvenGameState(player1, player2);
    }
}