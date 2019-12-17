using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public enum PlayerMoveChoices { computer, rock, paper, scissors }
    public class Result
    {
        public Guid ResultId { get; set; } = new Guid();
        public string PlayerName { get; set; }
        public string PlayerMove { get; set; }
        public int CurrentTurn { get; set; }
        public int WinCount { get; set; }
        public int DrawCount { get; set; }
        public PlayerMoveChoices Player1Move { get; set; }
        public PlayerMoveChoices Player2Move { get; set; }
        public string GameResult { get; set; }
    }
}
