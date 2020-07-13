using System.Linq;
using System.Threading.Tasks;
using GameManagerEntities.Models;

namespace GamesManagerRepository.Interfaces
{
    public interface IGameViewHistoriesRepository
    {
        /// <summary>
        /// Get all histories for specific game
        /// </summary>
        /// <param name="id">ID of desired game</param>
        /// <returns>Collection of histories for specific game</returns>
        IQueryable<GameViewHistory> GetAllHistoriesForGame(int id);

        /// <summary>
        /// Create history entry for specific game
        /// </summary>
        /// <param name="viewHistory">New history record</param>
        /// <returns>Created history entry</returns>
        Task<GameViewHistory> CreateHistoryEntryAsync(GameViewHistory viewHistory);
    }
}