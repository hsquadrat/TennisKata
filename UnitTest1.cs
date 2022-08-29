namespace TennisKata;

public class SpielTests
{
    private Player _player1 = new Player();
    private Player _player2 = new Player();
    
    private  SpielRegelCalculator _spielregelCalculator = new();

    [Fact]
    public void Game_Is_Started()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);
        //Act
        spiel.Play();

        //Assert
        Assert.True(spiel.IsSpielIsRunning());
    }

    [Fact]
    public void Game_Is_Started_Spielstand_Love_To_Love()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);

        //Act
        spiel.Play();
        var result = spiel.GetSpielstand();
        //Assert
        Assert.Equal("Love-All", result);
    }

    [Fact]
    public void Game_Spielstand_Fifteen_All()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);

        //Act
        spiel.Play();
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        var result = spiel.GetSpielstand();
        //Assert
        Assert.Equal("Fifteen-All", result);
    }

    [Fact]
    public void Game_Spielstand_Deuce()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);

        //Act
        spiel.Play();
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        var result = spiel.GetSpielstand();
        //Assert
        Assert.Equal("Deuce", result);
    }

    [Fact]
    public void Game_Spielstand_Advantage_Player1()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);

        //Act
        spiel.Play();
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        var result = spiel.GetSpielstand();
        //Assert
        Assert.Equal("Advantage player1", result);
    }

    [Fact]
    public void Game_Spielstand_Love_To_Fifteen()
    {
        //Arrange
        var spiel = new Spiel(_player1, _player2, _spielregelCalculator);

        //Act
        spiel.Play();
        spiel.SetSpielstand(_player1);
        spiel.SetSpielstand(_player2);
        spiel.SetSpielstand(_player1);
        var result = spiel.GetSpielstand();
        //Assert
        Assert.Equal("Thirty-Fifteen", result);
    }
}