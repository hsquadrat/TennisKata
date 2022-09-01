﻿namespace TennisKata;

public class UnEvenGameState : State
{
    private Player player1;
    private Player player2;

    public UnEvenGameState(Player player1, Player player2) : base(player1,player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }
    public override string getScore()
    {
        return player1.GetSpielstandzähler().ToString() + "-" + player2.GetSpielstandzähler();
    }

    public override State setPointToPlayer(Player playerWithPoint)
    {
        //playerWithPoint.SetSpielstandzhähler();
        
        if (playerWithPoint.GetSpielstandzähler() == GameCounter.Forty) {
            return new WinPlayerGameState(player1,player2);
        }

        if (playerWithPoint.GetSpielstandzähler() == player2.GetSpielstandzähler()) {
            if (playerWithPoint.GetSpielstandzähler() >= GameCounter.Thirty) {
                return new DeuceGameState(player1,player2);
            }
            return new EvenGameState(player1,player2);
        }

        return new UnEvenGameState(player1, player2);
    }
}