using Microsoft.AspNetCore.Mvc;
using RedisAPI2.Data;

namespace RedisAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;    
        public PlatformsController(IPlatformRepo repo)
        {
            _repo = repo;
        }
    }
}