namespace TennisKata;

public class Player
{
    private GameCounter spielstand;

    public Player()
    {
        spielstand = 0;
    }

    public GameCounter GetSpielstandz√§hler()
    {
        return spielstand;
    }

    public void SetSpielstandzh√§hler()
    {
        spielstand += 1;
    }
}