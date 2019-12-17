using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDemo.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options): base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
