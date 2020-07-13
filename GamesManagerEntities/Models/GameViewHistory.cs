using System;
using System.Collections.Generic;

namespace GameManagerEntities.Models
{
    public class GameViewHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; } = "Web API";

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}