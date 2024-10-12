using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP_LAB_8.Controllers
{
    public class CacheController : Controller
    {
        private readonly IMemoryCache _cache;

        public CacheController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET: /cache
        [HttpGet("/cache")]
        public IActionResult GetCachedData()
        {
            if (!_cache.TryGetValue("cachedData", out string cachedData))
            {
              
                cachedData = "Це кешовані дані, які згенеровані " + DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                _cache.Set("cachedData", cachedData, cacheEntryOptions);
            }

            return Content(cachedData);
        }
    }
}
