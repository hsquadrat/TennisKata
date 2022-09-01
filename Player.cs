namespace TennisKata;

public class Player
{
    private GameCounter spielstand;

    public Player()
    {
        spielstand = 0;
    }

    public GameCounter GetSpielstandzähler()
    {
        return spielstand;
    }

    public void SetSpielstandzhähler()
    {
        spielstand += 1;
    }
}