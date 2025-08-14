using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Assignment06.Models;
using Microsoft.Extensions.Configuration;

namespace Assignment06.Repositories
{
    public class ClinicRoleRepository : IClinicRoleRepository
    {
        private readonly string _connectionString;

        public ClinicRoleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ClinicRole> GetAll()
        {
            var roles = new List<ClinicRole>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT RoleID, RoleName FROM ClinicRoles", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new ClinicRole
                        {
                            RoleID = (int)reader["RoleID"],
                            RoleName = reader["RoleName"].ToString()
                        });
                    }
                }
            }
            return roles;
        }

        public ClinicRole GetById(int id)
        {
            ClinicRole role = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT RoleID, RoleName FROM ClinicRoles WHERE RoleID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = new ClinicRole
                        {
                            RoleID = (int)reader["RoleID"],
                            RoleName = reader["RoleName"].ToString()
                        };
                    }
                }
            }
            return role;
        }

        public void Add(ClinicRole clinicRole)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO ClinicRoles (RoleID, RoleName) VALUES (@id, @name)", conn);
                cmd.Parameters.AddWithValue("@id", clinicRole.RoleID);
                cmd.Parameters.AddWithValue("@name", clinicRole.RoleName);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ClinicRole clinicRole)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE ClinicRoles SET RoleName = @name WHERE RoleID = @id", conn);
                cmd.Parameters.AddWithValue("@id", clinicRole.RoleID);
                cmd.Parameters.AddWithValue("@name", clinicRole.RoleName);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM ClinicRoles WHERE RoleID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
