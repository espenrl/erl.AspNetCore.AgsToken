using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Powel.AspNetCore.AgsToken
{
    public class AgsTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AgsOptions _options;
        private readonly IMemoryCache _memoryCache;

        public AgsTokenMiddleware(RequestDelegate next, IOptions<AgsOptions> options, IMemoryCache memoryCache)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _memoryCache = memoryCache;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = await _memoryCache.GetOrCreateAsync("token", GetAgsToken);
            context.Request.QueryString = context.Request.QueryString.Add("token", token);

            await _next(context);
        }

        private async Task<string> GetAgsToken(ICacheEntry entry)
        {
            var tokenData = await AgsServer.GenerateToken(_options.Scheme, _options.Host, _options.Port, _options.Instance, _options.Username, _options.Password);

            // set cache entry expiry
            var expires = FromUnixTime(tokenData.expires);
            entry.AbsoluteExpiration = expires.AddMinutes(-1);

            return tokenData.token; 
        }

        private static DateTime FromUnixTime(long unixTime)
            => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(unixTime);
    }
}