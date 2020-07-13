using System.Data;
using System.Linq;
using AutoMapper;
using GameManagerEntities;
using GamesManagerRepository.Interfaces;
using System.Threading.Tasks;
using GameManagerEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesManagerRepository.Implementations
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GamesManagerDbContext _context;
        private readonly IMapper _mapper;

        public GamesRepository(GamesManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IQueryable<Game> GetAllGames()
        {
            return _context.Games
                .Include(g => g.GameViewHistories)
                .AsQueryable();
        }

        public async Task<Game> GetSingleGameAsync(int gameId)
        {
            return await _context.Games
                .FindAsync(gameId);
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            var result =  await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task UpdateGameAsync(int gameId, Game game)
        {
            var gameToUpdate = await _context.Games.FindAsync(gameId);

            if (gameToUpdate == null)
            {
                throw new RowNotInTableException();
            }
            
            gameToUpdate.Name = game.Name;
            gameToUpdate.MaxPlayers = game.MaxPlayers;
            gameToUpdate.MinAge = game.MinAge;
            gameToUpdate.MinPlayers = game.MinPlayers;
            
            await _context.SaveChangesAsync();
        }

        public async Task<Game> DeleteGameAsync(int gameId)
        {
            var gameToDelete = await _context.Games.FindAsync(gameId);
            
            if (gameToDelete == null)
            {
                throw new RowNotInTableException();
            }
            
            _context.Games.Remove(gameToDelete);
            await _context.SaveChangesAsync();

            return gameToDelete;
        }
    }
}