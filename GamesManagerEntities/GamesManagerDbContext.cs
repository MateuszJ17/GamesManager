using GameManagerEntities.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GameManagerEntities
{
    public class GamesManagerDbContext : DbContext
    {
        public GamesManagerDbContext()
        {
            
        }
        public GamesManagerDbContext(DbContextOptions<GamesManagerDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=GamesManager;Username=postgres;Password=Koleno789#");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameViewHistory> GameViewHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Id = 1,
                    Name = "Game 1",
                    MaxPlayers = 5,
                    MinPlayers = 2,
                    MinAge = 7
                },
                new Game()
                {
                    Id = 2,
                    Name = "Game 2",
                    MaxPlayers = 10,
                    MinPlayers = 5,
                    MinAge = 15
                },
                new Game()
                {
                    Id = 3,
                    Name = "Game 3",
                    MaxPlayers = 4,
                    MinPlayers = 1,
                    MinAge = 12
                },
                new Game()
                {
                    Id = 4,
                    Name = "Game 4",
                    MaxPlayers = 8,
                    MinPlayers = 2,
                    MinAge = 12
                },
                new Game()
                {
                    Id = 5,
                    Name = "Game 5",
                    MaxPlayers = 6,
                    MinPlayers = 2,
                    MinAge = 4
                },
                new Game()
                {
                    Id = 6,
                    Name = "Game 6",
                    MaxPlayers = 12,
                    MinPlayers = 4,
                    MinAge = 16
                }
            );
        }
    }
}