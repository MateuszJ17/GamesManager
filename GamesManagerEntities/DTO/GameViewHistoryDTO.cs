using System;
using System.Collections.Generic;

namespace GameManagerEntities.DTO
{
    public class GameViewHistoryDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int GameId { get; set; }
    }
}