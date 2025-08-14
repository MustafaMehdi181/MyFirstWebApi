using Assignment06.Models;
using System.Data.SqlClient;


namespace Assignment06.Repositories
{
  

    public class DoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString;

        public DoctorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var doctors = new List<Doctor>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT DoctorID, DoctorName, RoleID FROM Doctors", conn);

            await conn.OpenAsync(cancellationToken);
            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                doctors.Add(new Doctor
                {
                    DoctorID = reader.GetInt32(0),
                    DoctorName = reader.GetString(1),
                    RoleID = reader.GetInt32(2)
                });
            }

            return doctors;
        }

        public async Task<Doctor?> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default)
        {
            Doctor? doctor = null;

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT DoctorID, DoctorName, RoleID FROM Doctors WHERE DoctorID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", doctorId);

            await conn.OpenAsync(cancellationToken);
            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync(cancellationToken))
            {
                doctor = new Doctor
                {
                    DoctorID = reader.GetInt32(0),
                    DoctorName = reader.GetString(1),
                    RoleID = reader.GetInt32(2)
                };
            }

            return doctor;
        }

        public async Task<int> AddAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Doctors (DoctorID, DoctorName, RoleID) VALUES (@Id, @Name, @RoleID)", conn);

            cmd.Parameters.AddWithValue("@Id", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@Name", doctor.DoctorName);
            cmd.Parameters.AddWithValue("@RoleID", doctor.RoleID);

            await conn.OpenAsync(cancellationToken);
            return await cmd.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "UPDATE Doctors SET DoctorName = @Name, RoleID = @RoleID WHERE DoctorID = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@Name", doctor.DoctorName);
            cmd.Parameters.AddWithValue("@RoleID", doctor.RoleID);

            await conn.OpenAsync(cancellationToken);
            var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);

            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int doctorId, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM Doctors WHERE DoctorID = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", doctorId);

            await conn.OpenAsync(cancellationToken);
            var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);

            return rows > 0;
        }
    }

}
