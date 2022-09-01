namespace TennisKata;

public abstract class State
{
    protected Player player1;
    protected Player player2;
    
    protected State(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }
    public abstract string  getScore();
    public abstract State setPointToPlayer(Player playerWithPoint);
}
