using System.Collections.Generic;
using System.Threading.Tasks;
using NewsHubApi.Models.DataModels.Category;

namespace NewsHubApi.Providers.Category
{
    public interface ICategoryProvider
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
    }
}