using System.Collections.Generic;
using NewsHubApi.Models.ViewModels.Category;
using NewsHubApi.Collections;

namespace NewsHubApi.Mappers.Category
{
    public interface ICategoryMapper
    {
        IEnumerable<CategoryViewModel> Map(IEnumerable<Categories> model);
    }
}