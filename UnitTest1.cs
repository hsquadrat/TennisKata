namespace TennisKata;

public class SpielTests
{
    private  Player player1 = new Player("Holger Schwinge");
    private  Player player2 = new Player("Alex Gross");

    [Fact]
    public void Game_Is_Started()
    {
        //Arrange
        var spiel = new Spiel(player1, player2);
        //Act
        spiel.Play();
        
        //Assert
        Assert.True(spiel.IsSpielIsRunning());
    }
    
    [Fact]
    public void Game_Is_Started_Spielstand_Love_To_Love()
    {
        //Arrange
        var spiel = new Spiel(player1, player2);
        
        //Act
        spiel.Play();
        var result = spiel.Spielstand();
        //Assert
        Assert.Equal("Love:Love",result);
    }
}

public class Spiel
{
    private Player player1;
    private Player player2;
    private Player ball;

    private bool spielStart = false;
    private bool spielEnd = false;

    private bool unentschieden;

    public Spiel(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public void Play()
    {
        spielStart = true;
        unentschieden = false;
    }

    public void SetSpielstand(Player player)
    {
        player.SetSpielstandzhähler();
    }
    public bool IsSpielIsRunning()
    {
        return spielStart;
    }

    public string Spielstand()
    {
        return player1.GetSpielstandzhähler() + ":" + player2.GetSpielstandzhähler();
    }
}

public class Player
{
    private string fullName;
    private SpielstandZähler spielstand;
    public Player(string fullName)
    {
        this.fullName = fullName;
        this.spielstand = 0;
    }

    public SpielstandZähler GetSpielstandzhähler()
    {
        return spielstand;
    }

    public void SetSpielstandzhähler()
    {
        this.spielstand++;
    }
}



public enum SpielstandZähler : ushort
{
    Love = 0,
    fünfzehn = 1,
    dreizig = 2,
    vierzig = 3
}
