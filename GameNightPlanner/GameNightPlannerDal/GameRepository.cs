using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNightPlannerLogic;

namespace GameNightPlannerDal
{
    public class GameRepository : IGameRepository
    {
        private readonly string _connectionString;

        public GameRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                connection.Open();

                string query = "SELECT * FROM Game";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var game = new Game(
                                reader.GetInt32(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("Genre")),
                                reader.GetString(reader.GetOrdinal("Platform")),
                                reader.GetInt32(reader.GetOrdinal("EstimatedDuration")),
                                reader.GetInt32(reader.GetOrdinal("MinPlayers")),
                                reader.GetInt32(reader.GetOrdinal("MaxPlayers")),
                                reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl"))
                            );
                            games.Add(game);
                        }
                    }
                }
            }
            return games;
        }
    }
}
