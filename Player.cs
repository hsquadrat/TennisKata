namespace TennisKata;

public class Player
{
    private SpielstandZähler spielstand;

    public Player()
    {
        spielstand = 0;
    }

    public SpielstandZähler GetSpielstandzähler()
    {
        return spielstand;
    }

    public void SetSpielstandzhähler()
    {
        spielstand += 1;
    }
}