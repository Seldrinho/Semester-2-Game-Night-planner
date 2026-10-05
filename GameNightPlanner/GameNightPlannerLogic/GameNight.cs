using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerLogic
{
    public class GameNight
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public DateTime ProposalDeadline { get; private set; }
        public DateTime VotingDeadline { get; private set; }

        public int OrganiserId { get; private set; }
        public int GroupId { get; private set; }
        public GameNight(string name, string? description, DateTime proposalDeadline, DateTime votingDeadline, int organiserId, int groupId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A Title is required.");
            }

            if (proposalDeadline <= DateTime.Now)
            {
                throw new ArgumentException("Proposal deadline must be in the future.");
            }

            if (votingDeadline <= DateTime.Now)
            {
                throw new ArgumentException("Voting deadline must be in the future.");
            }

            if (proposalDeadline >= votingDeadline)
            {
                throw new ArgumentException("Proposal deadline must be before voting deadline.");
            }
            Name = name;
            Description = description;
            ProposalDeadline = proposalDeadline;
            VotingDeadline = votingDeadline;
            OrganiserId = organiserId;
            GroupId = groupId;
        }
    }
}
    
