using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using NewsHubApi.Models.DataModels.Category;
using System.Data.SqlClient;
using NewsHubApi.Constants;
using System.Web.Configuration;

namespace NewsHubApi.Providers.Category
{
    public class CategoryProvider : ICategoryProvider
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return connection.Query<CategoryModel>(SprocNames.GET_CATEGORIES, commandType: CommandType.StoredProcedure);
            }
        }

    }
}