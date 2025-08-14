
using System.Data.SqlClient;
using Assignment06.Models;


namespace Assignment06.Repositories
{
    public class VisitTypeRepository : IVisitTypeRepository
    {
        private readonly string _connectionString;

        public VisitTypeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<VisitType> GetAll()
        {
            var list = new List<VisitType>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT VisitTypeID, VisitTypeName FROM VisitTypes", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new VisitType
                {
                    VisitTypeID = (int)reader["VisitTypeID"],
                    VisitTypeName = reader["VisitTypeName"].ToString()
                });
            }
            return list;
        }

        public VisitType GetById(int id)
        {
            VisitType vt = null;
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT VisitTypeID, VisitTypeName FROM VisitTypes WHERE VisitTypeID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                vt = new VisitType
                {
                    VisitTypeID = (int)reader["VisitTypeID"],
                    VisitTypeName = reader["VisitTypeName"].ToString()
                };
            }
            return vt;
        }

        public void Add(VisitType visitType)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO VisitTypes (VisitTypeID, VisitTypeName) VALUES (@id, @name)", conn);
            cmd.Parameters.AddWithValue("@id", visitType.VisitTypeID);
            cmd.Parameters.AddWithValue("@name", visitType.VisitTypeName);
            cmd.ExecuteNonQuery();
        }

        public void Update(VisitType visitType)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("UPDATE VisitTypes SET VisitTypeName=@name WHERE VisitTypeID=@id", conn);
            cmd.Parameters.AddWithValue("@id", visitType.VisitTypeID);
            cmd.Parameters.AddWithValue("@name", visitType.VisitTypeName);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM VisitTypes WHERE VisitTypeID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
