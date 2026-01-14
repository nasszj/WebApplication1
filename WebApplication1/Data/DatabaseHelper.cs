using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DatabaseHelper(IConfiguration configuration)
    {
        private readonly string _connectionString = configuration.GetConnectionString("MijnDatabase")
            ?? throw new InvalidOperationException("Connection string 'MijnDatabase' not found");

        // BELONINGSPOT OPHALEN
        public BeloningsPot? GetBeloningsPot()
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT TOP 1 * FROM BeloningsPot", conn);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new BeloningsPot
            {
                Id = (int)reader["Id"],
                HuidigePunten = (int)reader["HuidigePunten"],
                DoelPunten = (int)reader["DoelPunten"],
                Ronde = (int)reader["Ronde"]
            };
        }

        // PUNTEN TOEVOEGEN / AFTREKKEN
        public void UpdatePunten(int nieuweWaarde)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "UPDATE BeloningsPot SET HuidigePunten = @punten WHERE Id = 1", conn);
            cmd.Parameters.AddWithValue("@punten", nieuweWaarde);

            cmd.ExecuteNonQuery();
        }
    }
}