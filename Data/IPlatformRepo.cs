using RedisAPI2.Models;

namespace RedisAPI2.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }


}
