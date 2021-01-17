using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VesizleMvcCore.Models;

namespace VesizleMvcCore.DataAccess.RoleDal
{
    public class RoleDal : IRoleDal
    {
        public IConfiguration Configuration { get; }

        public RoleDal(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<RoleDetailViewModel> GetRoles()
        {
            List<RoleDetailViewModel> roles = new List<RoleDetailViewModel>();
            using (SqlConnection connection = new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Select * from GetRoles", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add(new RoleDetailViewModel()
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString(),
                            ConcurrencyStamp = reader["ConcurrencyStamp"].ToString()
                        });
                    }
                    connection.Close();
                }
            }

            return roles;
        }
    }
}
