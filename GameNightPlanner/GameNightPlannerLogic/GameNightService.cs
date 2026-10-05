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
            ValidateGameNight(gameNight);
            if (!_gameNightRepository.IsUserMemberOfGroup(gameNight.OrganiserId, gameNight.GroupId))
            {
                throw new UnauthorizedAccessException("User is not a member of the group.");
            }
            _gameNightRepository.Add(gameNight);
        }

        private void ValidateGameNight(GameNight gameNight)
        {
            ArgumentNullException.ThrowIfNull(gameNight);

            if (string.IsNullOrWhiteSpace(gameNight.Name))
            {
                throw new ArgumentException("A Title is required.");
            }
            if (gameNight.ProposalDeadline <= DateTime.Now)
            {
                throw new ArgumentException("Proposal deadline must be in the future.");
            }
            if (gameNight.ProposalDeadline >= gameNight.VotingDeadline)
            {
                throw new ArgumentException("Proposal deadline must be before voting deadline.");
            }
        }
    }
}
