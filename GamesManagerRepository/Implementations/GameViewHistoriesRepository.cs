using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameManagerEntities;
using GameManagerEntities.Models;
using GamesManagerRepository.Interfaces;

namespace GamesManagerRepository.Implementations
{
    public class GameViewHistoriesRepository : IGameViewHistoriesRepository
    {
        private readonly GamesManagerDbContext _context;
        private readonly IMapper _mapper;

        public GameViewHistoriesRepository(GamesManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<GameViewHistory> GetAllHistoriesForGame(int id)
        {
            var result = _context.GameViewHistories
                .Where(g => g.GameId == id)
                .OrderByDescending(x => x.Date)
                .Take(10)
                .AsQueryable();

            return result;
        }

        public async Task<GameViewHistory> CreateHistoryEntryAsync(GameViewHistory viewHistory)
        {
            var result = await _context.GameViewHistories.AddAsync(viewHistory);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}