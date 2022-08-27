namespace TennisKata;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var player1 = new Player("Holger Schwinge");
        var player2 = new Player("Alex Gross");
        var spiel = new Spiel(player1, player2, player1);
        
        //Act
        spiel.Play();
        
        //Assert
        Assert.True(spiel.IsSpielGeStartet());
    }
}

public class Spiel
{
    private Player player1;
    private Player player2;
    private Player ballBesitz;

    private bool spielStart = false;
    private bool spielEnd = false;
    public Spiel(Player player1, Player player2, Player ballBesitz)
    {
        this.player1 = player1;
        this.player2 = player2;
        this.ballBesitz = ballBesitz;
    }

    public void Play()
    {
        spielStart = true;
    }

    public bool IsSpielGeStartet()
    {
        return spielStart;
    }
    
}

public class Player
{
    private string fullName;
    public Player(string fullName)
    {
        this.fullName = fullName;
    }
}