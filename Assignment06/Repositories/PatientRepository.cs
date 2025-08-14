using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Repositories
{
    
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var patients = new List<Patient>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT PatientID, PatientName FROM Patients", conn);

            await conn.OpenAsync(cancellationToken);
            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                patients.Add(new Patient
                {
                    PatientID = reader.GetInt32(0),
                    PatientName = reader.GetString(1)
                });
            }

            return patients;
        }

        public async Task<Patient?> GetByIdAsync(int patientId, CancellationToken cancellationToken = default)
        {
            Patient? patient = null;

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT PatientID, PatientName FROM Patients WHERE PatientID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", patientId);

            await conn.OpenAsync(cancellationToken);
            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync(cancellationToken))
            {
                patient = new Patient
                {
                    PatientID = reader.GetInt32(0),
                    PatientName = reader.GetString(1)
                };
            }

            return patient;
        }

        public async Task<int> AddAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Patients (PatientID, PatientName) VALUES (@Id, @Name)", conn);

            cmd.Parameters.AddWithValue("@Id", patient.PatientID);
            cmd.Parameters.AddWithValue("@Name", patient.PatientName);

            await conn.OpenAsync(cancellationToken);
            return await cmd.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "UPDATE Patients SET PatientName = @Name WHERE PatientID = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", patient.PatientID);
            cmd.Parameters.AddWithValue("@Name", patient.PatientName);

            await conn.OpenAsync(cancellationToken);
            var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);

            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM Patients WHERE PatientID = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", patientId);

            await conn.OpenAsync(cancellationToken);
            var rows = await cmd.ExecuteNonQueryAsync(cancellationToken);

            return rows > 0;
        }
    }

}
