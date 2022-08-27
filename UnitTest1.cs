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
        Assert.Equal("(Love:Love)",result);
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

    private Spielstand spielStand = new Spielstand(0, 0);
    
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

    public bool IsSpielIsRunning()
    {
        return spielStart;
    }

    public object Spielstand()
    {
        return spielStand.ToString();
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

public readonly struct Spielstand
{
    public Spielstand(SpielstandZähler x, SpielstandZähler y)
    {
        X = x;
        Y = y;
    }

    public SpielstandZähler X { get; init; }
    public SpielstandZähler Y { get; init; }

    public override string ToString() => $"({X}:{Y})";
}

public enum SpielstandZähler : ushort
{
    Love = 0,
    fünfzehn = 1,
    dreizig = 100,
    vierzig = 200
}
