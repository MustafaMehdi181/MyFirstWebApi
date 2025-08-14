using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Assignment06.Models;
using Microsoft.Extensions.Configuration;

namespace Assignment06.Repositories
{
    public class VisitDetailRepository : IVisitDetailRepository
    {
        private readonly string _connectionString;

        public VisitDetailRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<VisitDetail> GetAll()
        {
            var visitDetails = new List<VisitDetail>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM VisitDetails";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    visitDetails.Add(new VisitDetail
                    {
                        VisitID = (int)reader["VisitID"],
                        PatientID = (int)reader["PatientID"],
                        DoctorID = (int)reader["DoctorID"],
                        VisitTypeID = (int)reader["VisitTypeID"],
                        VisitDate = (DateTime)reader["VisitDate"],
                        Duration = (int)reader["Duration"],
                        DoctorNotes = reader["DoctorNotes"] as string
                    });
                }
            }
            return visitDetails;
        }

        public VisitDetail GetById(int id)
        {
            VisitDetail visitDetail = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM VisitDetails WHERE VisitID = @VisitID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VisitID", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    visitDetail = new VisitDetail
                    {
                        VisitID = (int)reader["VisitID"],
                        PatientID = (int)reader["PatientID"],
                        DoctorID = (int)reader["DoctorID"],
                        VisitTypeID = (int)reader["VisitTypeID"],
                        VisitDate = (DateTime)reader["VisitDate"],
                        Duration = (int)reader["Duration"],
                        DoctorNotes = reader["DoctorNotes"] as string
                    };
                }
            }
            return visitDetail;
        }

        public void Add(VisitDetail visitDetail)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO VisitDetails (VisitID, PatientID, DoctorID, VisitTypeID, VisitDate, Duration, DoctorNotes) 
                                 VALUES (@VisitID, @PatientID, @DoctorID, @VisitTypeID, @VisitDate, @Duration, @DoctorNotes)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VisitID", visitDetail.VisitID);
                cmd.Parameters.AddWithValue("@PatientID", visitDetail.PatientID);
                cmd.Parameters.AddWithValue("@DoctorID", visitDetail.DoctorID);
                cmd.Parameters.AddWithValue("@VisitTypeID", visitDetail.VisitTypeID);
                cmd.Parameters.AddWithValue("@VisitDate", visitDetail.VisitDate);
                cmd.Parameters.AddWithValue("@Duration", visitDetail.Duration);
                cmd.Parameters.AddWithValue("@DoctorNotes", (object)visitDetail.DoctorNotes ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(VisitDetail visitDetail)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE VisitDetails 
                                 SET PatientID = @PatientID, DoctorID = @DoctorID, VisitTypeID = @VisitTypeID, VisitDate = @VisitDate, 
                                     Duration = @Duration, DoctorNotes = @DoctorNotes
                                 WHERE VisitID = @VisitID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VisitID", visitDetail.VisitID);
                cmd.Parameters.AddWithValue("@PatientID", visitDetail.PatientID);
                cmd.Parameters.AddWithValue("@DoctorID", visitDetail.DoctorID);
                cmd.Parameters.AddWithValue("@VisitTypeID", visitDetail.VisitTypeID);
                cmd.Parameters.AddWithValue("@VisitDate", visitDetail.VisitDate);
                cmd.Parameters.AddWithValue("@Duration", visitDetail.Duration);
                cmd.Parameters.AddWithValue("@DoctorNotes", (object)visitDetail.DoctorNotes ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM VisitDetails WHERE VisitID = @VisitID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VisitID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
