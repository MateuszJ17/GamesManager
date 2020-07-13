using System.Collections.Generic;

namespace GameManagerEntities.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public string Source { get; set; } = "Web API";

        public IEnumerable<GameViewHistoryDTO> GameViewHistories { get; set; }
    }
}