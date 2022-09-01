namespace TennisKata;



public class Spiel
{
    private readonly Player player1;
    private readonly Player player2;
    private State state;
    
    public Spiel(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        this.state =  new InitialState(player1,player2);
    }
    
    public void SetSpielstand(Player setPlayer)
    {
        
        setPlayer.SetSpielstandzhähler();
        state = state.setPointToPlayer(setPlayer);
    }
    
    public string GetSpielstand()
    {
        return state.getScore();
    }
}