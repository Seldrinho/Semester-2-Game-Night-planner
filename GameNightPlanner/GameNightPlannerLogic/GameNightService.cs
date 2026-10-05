using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerLogic
{
    public class GameNightService
    {
        private readonly IGameNightRepository _gameNightRepository;

        public GameNightService(IGameNightRepository gameNightRepository)
        {
            _gameNightRepository = gameNightRepository;
        }

        public void CreateGameNight(GameNight gameNight)
        {
            
            if (!_gameNightRepository.IsUserMemberOfGroup(gameNight.OrganiserId, gameNight.GroupId))
            {
                throw new UnauthorizedAccessException("User is not a member of the group.");
            }
            _gameNightRepository.Add(gameNight);
        }

        
    }
}
