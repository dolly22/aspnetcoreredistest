using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using System.Threading;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices]IDistributedCache cache)
        {
            var hitat = DateTime.UtcNow;
            var sw = new Stopwatch();
            sw.Start();

            var value = await cache.GetAsync("cache_key");
            sw.Stop();

            Thread.Sleep(20000);

            var rederedat = DateTime.UtcNow;
            return new ContentResult()
            {
                ContentType = "text/plain",
                Content = $"Hit at {hitat}, rendered {rederedat}, cache get duration {sw.ElapsedMilliseconds} ms"
            };
        }
    }
}
