using System.Collections.Generic;
using NewsHubApi.Models.DataModels.Category;
using NewsHubApi.Models.ViewModels.Category;

namespace NewsHubApi.Mappers.Category
{
    public interface ICategoryMapper
    {
        IEnumerable<CategoryViewModel> Map(IEnumerable<CategoryModel> model);
    }
}