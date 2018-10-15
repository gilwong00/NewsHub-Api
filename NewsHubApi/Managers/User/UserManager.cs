using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NewsHubApi.Models.DataModels.User;
using System.Web.Configuration;

namespace NewsHubApi.Managers.User
{
    public class UserManager : IUserManager
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;

        public async Task<bool> AddNewUser(NewUserDataModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    connection.Execute("", model, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}