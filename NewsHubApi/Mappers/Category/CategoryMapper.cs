using NewsHubApi.Models.DataModels.Category;
using NewsHubApi.Models.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsHubApi.Mappers.Category
{
    public class CategoryMapper : ICategoryMapper
    {
        public IEnumerable<CategoryViewModel> Map(IEnumerable<CategoryModel> model)
        {
            return model.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            });
        } 
    }
}