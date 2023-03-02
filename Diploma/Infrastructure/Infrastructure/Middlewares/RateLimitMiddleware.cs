using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;

        public RateLimitMiddleware(RequestDelegate next, IDistributedCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string ipAddress = context.Connection.RemoteIpAddress!.ToString();
            string endpointUrl = context.Request.Path.ToString();

            string key = $"{ipAddress}:{endpointUrl}";

            string? count = await _cache.GetStringAsync(key);

            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA: " + count);

            if (!string.IsNullOrEmpty(count))
            {
                int currentCount = int.Parse(count);
                currentCount++;
                await _cache.SetStringAsync(key, currentCount.ToString(), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });

                if (currentCount > 10)
                {
                    context.Response.StatusCode = 429;
                    await context.Response.WriteAsync("Too many requests. Please try again later.");
                    return;
                }
            }
            else
            {
                await _cache.SetStringAsync(key, "1", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }

            await _next(context);
        }
    }
}
