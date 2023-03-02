using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Filters
{
    public class RateLimitAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string ipAddress = context.HttpContext.Connection.RemoteIpAddress!.ToString();
            string endpointUrl = context.HttpContext.Request.Path.ToString();

            string key = $"{ipAddress}:{endpointUrl}";

            IDistributedCache? cache = context.HttpContext.RequestServices.GetService<IDistributedCache>();
            string? count = cache?.GetString(key);
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA: " + count);

            if (!string.IsNullOrEmpty(count))
            {
                int currentCount = int.Parse(count);
                currentCount++;
                cache?.SetString(key, currentCount.ToString(), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });

                if (currentCount > 10)
                {
                    context.Result = new StatusCodeResult(429);
                }
            }
            else
            {
                cache?.SetString(key, "1", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }

            base.OnActionExecuting(context);
        }
    }
}
