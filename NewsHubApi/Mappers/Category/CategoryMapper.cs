using NewsHubApi.Collections;
using NewsHubApi.Models.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

namespace NewsHubApi.Mappers.Category
{
    public class CategoryMapper : ICategoryMapper
    {
        public IEnumerable<CategoryViewModel> Map(IEnumerable<Categories> model)
        {
            return model.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            });
        } 
    }
}