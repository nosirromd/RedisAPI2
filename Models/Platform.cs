namespace RedisAPI2.Models
{
    public class Platform
    {
        public string Id { get; set; } = $"platform:{Guid.NewGuid}";

        public string Name { get; set; } = string.Empty;
    }
}