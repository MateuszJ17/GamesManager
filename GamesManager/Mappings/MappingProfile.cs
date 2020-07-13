using AutoMapper;
using GameManagerEntities.DTO;
using GameManagerEntities.Models;

namespace GamesManager.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDTO>();
            CreateMap<GameDTO, Game>();
            CreateMap<GameViewHistory, GameViewHistoryDTO>();
            CreateMap<GameViewHistoryDTO, GameViewHistory>();
        }
    }
}