using MongoDB.Driver;

namespace NewsHubApi.MongoDB
{
    public interface IMongoDBHelper
    {
        IMongoDatabase OpenMongoDBConnection();
    }
}