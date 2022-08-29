namespace TennisKata;

public class Spiel
{
    private readonly Player player1;
    private readonly Player player2;

    private readonly SpielRegelCalculator spielRegelCalculator;

    private bool spielStart;

    private bool unentschieden;

    public Spiel(Player player1, Player player2, SpielRegelCalculator spielRegelCalculator)
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