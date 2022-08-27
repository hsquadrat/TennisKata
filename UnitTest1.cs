namespace TennisKata;

public class SpielTests
{
    private  Player player1 = new Player("Holger Schwinge");
    private  Player player2 = new Player("Alex Gross");
    private SpielRegelCalculator spielregelCalculator = new SpielRegelCalculator();
    
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
        Assert.Equal("Love-All",result);
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

    private SpielRegelCalculator spielRegelCalculator;
    
    public Spiel(Player player1, Player player2,SpielRegelCalculator spielRegelCalculator )
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

    public void SetSpielstand(Player setPlayer)
    {
        setPlayer.SetSpielstandzhähler();
    }
    public bool IsSpielIsRunning()
    {
        return spielStart;
    }

    public string GetSpielstand()
    {
        return spielRegelCalculator.Calculate(player1, player2);
    }
}

public interface ISpielregelCalculator
{
   public string Calculate(Player player1, Player player2);
}

public class SpielRegelCalculator : ISpielregelCalculator
{
    private SpielstandZähler score1 = 0;
    private SpielstandZähler score2 = 0;
    private SpielstandZähler tempScore = 0;
    string score = "";
    
    public string Calculate(Player player1, Player player2)
    {
        score1 = player1.GetSpielstandzhähler();
        score2 = player2.GetSpielstandzhähler();
        
        if (score1.Equals(score2))
        {
            switch (score1)
            {
                case SpielstandZähler.Love:
                    score = "Love-All";
                    break;
                case SpielstandZähler.Fifteen:
                    score = "Fifteen-All";
                    break;
                case SpielstandZähler.Thirty:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;

            }
        }
        else if (score1 >= SpielstandZähler.Fourty || score2 >= SpielstandZähler.Fourty)
        {
            var minusResult = score1 - score2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
        }
        else
        {
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = score1;
                else { score += "-"; tempScore = score2; }
                switch (tempScore)
                {
                    case SpielstandZähler.Love:
                        score += "Love";
                        break;
                    case SpielstandZähler.Fifteen:
                        score += "Fifteen";
                        break;
                    case SpielstandZähler.Thirty:
                        score += "Thirty";
                        break;
                    case SpielstandZähler.Fourty:
                        score += "Forty";
                        break;
                }
            }
        }
        return score;
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
        this.spielstand +=1;
    }
}



public enum SpielstandZähler : ushort
{
    Love = 0,
    Fifteen = 1,
    Thirty = 2,
    Fourty = 3,
    Deuce = 4,
    Advantage = 5,
    Game = 6
}

