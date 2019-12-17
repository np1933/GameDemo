using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        public string PlayerName { get; set; }
        public Move Move { get; set; }
        public int WinCount { get; set; }
    }
}
