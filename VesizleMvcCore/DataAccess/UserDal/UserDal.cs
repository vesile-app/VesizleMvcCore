using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using VesizleMvcCore.Models;
using Microsoft.Extensions.Configuration;
namespace VesizleMvcCore.DataAccess.UserDal
{
    public class UserDal : IUserDal
    {
        public IConfiguration Configuration { get; }

        public UserDal(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<UserDetailForAdminModel> GetUsers()
        {
            List<UserDetailForAdminModel> users = new List<UserDetailForAdminModel>();
            using (SqlConnection connection = new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
            {
                using (SqlCommand command = new SqlCommand("Select * from GetUsers", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new UserDetailForAdminModel()
                        {
                            Email = reader["Email"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Id = reader["Id"].ToString(),
                            EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                    connection.Close();
                }
            }

            return users;
        }
    }
}
