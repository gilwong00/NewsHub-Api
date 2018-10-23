using MongoDB.Driver;
using NewsHubApi.Collections;
using NewsHubApi.Mappers.Category;
using NewsHubApi.MongoDB;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NewsHubApi.Controllers.Api
{
    [RoutePrefix("api/category")]
    public class CategoriesApiController : ApiController
    {
        //mappers
        private readonly ICategoryMapper _categoryMapper;

        //helpers
        private readonly IMongoDBHelper _mongoDBHelper;

        public CategoriesApiController(
                ICategoryMapper categoryMapper,
                IMongoDBHelper mongoDBHelper
            )
        {
            _categoryMapper = categoryMapper;
            _mongoDBHelper = mongoDBHelper;
        }

        [Route, HttpGet]
        //[JwtAuthentication]
        public async Task<HttpResponseMessage> GetCategories()
        {
            try
            {
                var db = _mongoDBHelper.OpenMongoDBConnection().GetCollection<Categories>("Categories");
                var categories = await db.Find(Builders<Categories>.Filter.Empty).ToListAsync();
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
