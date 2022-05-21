using System.Text.Json;
using RedisAPI2.Models;
using StackExchange.Redis;

namespace RedisAPI2.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentOutOfRangeException(nameof(plat));
            }

            var db = _redis.GetDatabase();
            var serialPlat = JsonSerializer.Serialize(plat);
            db.StringSet(plat.Id, serialPlat);
            db.SetAdd("PlatformSet",serialPlat);
        }

        public IEnumerable<Platform?>? GetAllPlatforms()
        {
            var db = _redis.GetDatabase();
            var platformSet = db.SetMembers("PlatformSet");
            if (platformSet.Length > 0)
            {
                var obj =  Array.ConvertAll(platformSet ,element => JsonSerializer.Deserialize<Platform>(element) ).ToList();
                return obj;
            }
            return null;
        }

        public Platform? GetPlatformById(string id)
        {
            if (id == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var db = _redis.GetDatabase();
            var serialPlat = db.StringGet(id);
            if (!string.IsNullOrEmpty(serialPlat))
            {
                return JsonSerializer.Deserialize<Platform>(serialPlat);
            }

            return null;
        }
    }
}