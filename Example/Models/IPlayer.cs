using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public interface IPlayer
    {
        string PlayerName { get; set; }
        Move Move { get; set; }
    }
}
