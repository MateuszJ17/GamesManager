using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameManagerEntities.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(length: 50)]
        public string Name { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }

        public IEnumerable<GameViewHistory> GameViewHistories { get; set; }
    }
}