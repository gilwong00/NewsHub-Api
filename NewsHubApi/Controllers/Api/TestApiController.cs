using NewsHubApi.Collections;
using NewsHubApi.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NewsHubApi.Controllers.Api
{
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController
    {
        private readonly IMongoDBHelper _mongoDBHelper;

        public TestApiController(
                IMongoDBHelper mongoDBHelper
            )
        {
            _mongoDBHelper = mongoDBHelper;
        }

        [Route, HttpGet]
        public void TestMongo()
        {
            var db = _mongoDBHelper.OpenMongoDBConnection();
            db.CreateCollection("Categories");
        }

        [Route("add"), HttpGet]
        public bool AddToCollection()
        {
            var db = _mongoDBHelper.OpenMongoDBConnection();
            var collection = db.GetCollection<Categories>("Categories");
            var list = new List<Categories>()
            {
                new Categories {CategoryId = 1, CategoryName = "React"},
                new Categories {CategoryId = 2, CategoryName = "Javascript"},
                new Categories {CategoryId = 3, CategoryName = "Vue"},
                new Categories {CategoryId = 4, CategoryName = "C#"},

            };

            foreach (var x in list)
            {
                collection.InsertOne(new Categories { CategoryId = x.CategoryId, CategoryName = x.CategoryName });
            }
            
            return true;
        }
    }
}
