using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;


namespace NewsHubApi.Cache
{
    public static class Caching
    {
        public static dynamic GetObjectFromCache(string cacheItem)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedData = cache.Get(cacheItem);
            return cachedData;
        }

        public static void SetCache(string cacheItemName, dynamic data)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(20))
            };

            MemoryCache.Default.Set(cacheItemName, data, policy);
        }
    }
}