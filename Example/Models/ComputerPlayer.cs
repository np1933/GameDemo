using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public class ComputerPlayer : Player, IPlayer
    {
        static Array values = Enum.GetValues(typeof(Move));

        // If we created a new Random instance repeatedly we wouldnt get a good distribution of moves
        static Random random = new Random();

        public ComputerPlayer()
        {
            this.GetMove();
        }

        public Move GetMove()
        {
            Move randomMove;

            // the Random class is not type safe so we lock it here
            lock (random)
            {
                randomMove = (Move)values.GetValue(random.Next(values.Length));
            }

            Move = randomMove;
            return randomMove;
        }
    }
}
