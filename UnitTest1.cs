namespace TennisKata;

public class SpielTests
{
    private  Player player1 = new Player("Holger Schwinge");
    private  Player player2 = new Player("Alex Gross");
    private SpielregelCalculator spielregelCalculator = new SpielregelCalculator();
    
    [Fact]
    public void Game_Is_Started()
    {
        //Arrange
        var spiel = new Spiel(player1, player2,spielregelCalculator);
        //Act
        spiel.Play();
        
        //Assert
        Assert.True(spiel.IsSpielIsRunning());
    }
    
    [Fact]
    public void Game_Is_Started_Spielstand_Love_To_Love()
    {
        //Arrange
        var spiel = new Spiel(player1, player2,spielregelCalculator);
        
        //Act
        spiel.Play();
        var result = spiel.GetSpielstand();
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

    private SpielregelCalculator spielRegelCalculator;
    
    public Spiel(Player player1, Player player2,SpielregelCalculator spielRegelCalculator )
    {
        this.player1 = player1;
        this.player2 = player2;
        this.spielRegelCalculator = spielRegelCalculator;
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

    public string GetSpielstand()
    {
        return spielRegelCalculator.Calculate(player1,player2);
    }
}

public interface ISpielregelCalculator
{
   public string Calculate(Player player1, Player player2);
}

public interface IRules
{
    public string Calculate(int stand1 , int stand2);
}

public class RuleHochzählen : IRules
{
    public string Calculate(int stand1, int stand2)
    {
        throw new NotImplementedException();
    }
}
public class SpielregelCalculator : ISpielregelCalculator
{
    public string Calculate(Player player1, Player player2)
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
