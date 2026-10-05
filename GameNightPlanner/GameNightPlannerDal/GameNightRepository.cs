using GameNightPlannerLogic;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerDal
{ 
    public class GameNightRepository : IGameNightRepository
    {
        private readonly string _connectionString;

        public GameNightRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool IsUserMemberOfGroup(int userId, int groupId)
        {
            return userId == 1 && groupId == 1; //Hardcoded for now
        }
        public void Add(GameNight gameNight)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = """
        INSERT INTO GameNight
        (
            title,
            description,
            proposalDeadline,
            votingDeadline,
            Groupid,
            OrganizerUserid
        )
        VALUES
        (
            @Title,
            @Description,
            @ProposalDeadline,
            @VotingDeadline,
            @GroupId,
            @OrganizerUserId
        )
        """;

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", gameNight.Name);
            command.Parameters.AddWithValue("@Description", (object?)gameNight.Description ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProposalDeadline", gameNight.ProposalDeadline);
            command.Parameters.AddWithValue("@VotingDeadline", gameNight.VotingDeadline);
            command.Parameters.AddWithValue("@GroupId", gameNight.GroupId);
            command.Parameters.AddWithValue("@OrganizerUserId", gameNight.OrganiserId);

            command.ExecuteNonQuery();
        }
    }
}