using System.Linq;
using System.Threading.Tasks;
using GameManagerEntities.Models;

namespace GamesManagerRepository.Interfaces
{
    public interface IGamesRepository
    {
        /// <summary>
        /// Get all games
        /// </summary>
        /// <returns>IQueryable of games</returns>
        IQueryable<Game> GetAllGames();
        
        /// <summary>
        /// Get single game
        /// </summary>
        /// <param name="gameId">ID of desired game</param>
        /// <returns>Single game</returns>
        Task<Game> GetSingleGameAsync(int gameId);
        
        /// <summary>
        /// Create new game
        /// </summary>
        /// <param name="game">New game</param>
        /// <returns>Created game</returns>
        Task<Game> CreateGameAsync(Game game);
        
        /// <summary>
        /// Update existing game
        /// </summary>
        /// <param name="gameId">ID of desired game</param>
        /// <param name="game">Updated game</param>
        Task UpdateGameAsync(int gameId, Game game);
        
        /// <summary>
        /// Delete game
        /// </summary>
        /// <param name="gameId">ID of desired game</param>
        /// <returns>Deleted game</returns>
        Task<Game> DeleteGameAsync(int gameId);
    }
}