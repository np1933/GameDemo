using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public enum Move { Rock, Paper, Scissors };
    public enum GameResult { Player1Wins, Player2Wins, Draw };
    public interface IGame
    {
        Player Player1 { get; }
        Player Player2 { get; }
        GameResult DecideWinner();
        GameResult DecideWinner(Move player1Move, Move player2Move);
    }
}
