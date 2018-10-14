using NewsHubApi.Filters;
using NewsHubApi.Mappers.Category;
using NewsHubApi.Providers.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NewsHubApi.Controllers.Api
{
    [RoutePrefix("api/category")]
    public class CategoriesApiController : ApiController
    {
        //providers
        private readonly ICategoryProvider _categoryProvider;

        //mappers
        private readonly ICategoryMapper _categoryMapper;

        public CategoriesApiController(
                ICategoryProvider categoryProvider,
                ICategoryMapper categoryMapper
            )
        {
            _categoryProvider = categoryProvider;
            _categoryMapper = categoryMapper;
        }

        [Route, HttpGet]
        //[JwtAuthentication]
        public async Task<HttpResponseMessage> GetCategories()
        {
            try
            {
                var categories = await _categoryProvider.GetAllCategories();
                var response = _categoryMapper.Map(categories);
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, err.Message);
            }
        }
    }
}
