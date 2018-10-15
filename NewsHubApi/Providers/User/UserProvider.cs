using NewsHubApi.Models.DataModels.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace NewsHubApi.Providers.User
{
    public class UserProvider : IUserProvider
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;

        public async Task<UserModel> GetUser(UserModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return connection.Query<UserModel>("", new { Email = model.Email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}