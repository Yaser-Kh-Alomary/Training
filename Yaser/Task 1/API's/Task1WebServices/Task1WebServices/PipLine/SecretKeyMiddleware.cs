using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1WebServices.PipLine
{
    public class SecretKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKey = "SE-YASER-API-KEY";

        public SecretKeyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKey, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not provided.");
                return;

            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var appKey = appSettings.GetValue<string>(APIKey);

            if (!appKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthrized request.");
                return;
            }

            await _next(context);
        }
    }
}
