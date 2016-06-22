using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Powel.AspNetCore.AgsToken
{
    public static class AgsTokenExtension
    {
        /// <summary>
        /// Add AGS token to request as specified in options
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAgsToken(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<AgsTokenMiddleware>();
        }

        /// <summary>
        /// Add AGS token to request as specified in options
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options">Options for setting port, host, instance, username and password</param>
        /// <returns></returns>
        public static IApplicationBuilder UseAgsToken(this IApplicationBuilder app, AgsOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<AgsTokenMiddleware>(Options.Create(options));
        }
    }
}