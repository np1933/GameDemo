using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public class Game
    {
        public Player Player1 { get; }
        public Player Player2 { get; }

        public GameResult FindWinner()
        {
            return FindWinner(Player1.Move, Player2.Move);
        }

        public GameResult FindWinner(Move player1Move, Move player2Move)
        {
            GameResult result = GameResult.Draw;

            if ((player1Move == Move.Paper && player2Move == Move.Rock) ||
                (player1Move == Move.Rock && player2Move == Move.Scissors) ||
                (player1Move == Move.Scissors && player2Move == Move.Paper))
            {
                result = GameResult.Player1Wins;
            }

            if ((player1Move == Move.Rock && player2Move == Move.Paper) ||
               (player1Move == Move.Scissors && player2Move == Move.Rock) ||
               (player1Move == Move.Paper && player2Move == Move.Scissors))
            {
                result = GameResult.Player2Wins;
            }

            return result;
        }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;

            if (string.IsNullOrEmpty(Player1.PlayerName))
            {
                Player1.PlayerName = "Player1";
            }

            if (string.IsNullOrEmpty(Player2.PlayerName))
            {
                Player2.PlayerName = "Player2";
            }
        }
    }
}
