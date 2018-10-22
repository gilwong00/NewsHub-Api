using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace NewsHubApi.MongoDB
{
    public class MongoDBHelper : IMongoDBHelper
    {
        private string mongoDBConnection = WebConfigurationManager.AppSettings["Mongo"];

        public IMongoDatabase OpenMongoDBConnection()
        {
            return new MongoClient().GetDatabase(mongoDBConnection);
        }
    }
}