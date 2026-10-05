using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerLogic
{
    internal class Game
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string ImageUrl { get; private set; } = string.Empty;
        public string Genre { get; private set; } = string.Empty;
        public string Platform { get; private set; } = string.Empty;
        public TimeSpan estimatedDuration { get; private set; }
        public int MinPlayers { get; private set; }
        public int MaxPlayers { get; private set; }

    }
}
