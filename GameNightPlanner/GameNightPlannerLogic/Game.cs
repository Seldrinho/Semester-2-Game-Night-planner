using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerLogic
{
    public class Game
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public string Genre { get; private set; } = string.Empty;
        public string Platform { get; private set; } = string.Empty;
        public int EstimatedDuration { get; private set; }
        public int MinPlayers { get; private set; }
        public int MaxPlayers { get; private set; }

        public Game(int id, string name, string genre, string platform, int estimatedDuration, int minPlayers, int maxPlayers, string? description = null, string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A game name is required.");
            }
            if (string.IsNullOrWhiteSpace(genre))
            {
                throw new ArgumentException("A genre is required.");
            }
            if (string.IsNullOrWhiteSpace(platform))
            {
                throw new ArgumentException("A platform is required.");
            }
            if (estimatedDuration <= 0)
            {
                throw new ArgumentException("Estimated duration must be positive.");
            }
            if (minPlayers <= 0)
            {
                throw new ArgumentException("Minimum players must be positive.");
            }
            if (maxPlayers < minPlayers)
            {
                throw new ArgumentException("Maximum players must be greater than or equal to minimum players.");
            }
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Genre = genre;
            Platform = platform;
            EstimatedDuration = estimatedDuration;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

    }
}
