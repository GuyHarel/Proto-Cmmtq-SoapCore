using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml.Schema;

namespace TestProject.Middlewares
{
    public class SoapRequestMiddleware
    {

        private readonly RequestDelegate _next;

        public SoapRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Les URL asmx doivent être authentifiés

            try
            {
                if (context.Request.Path.HasValue &&
                    context.Request.Path.Value.EndsWith(".asmx", StringComparison.OrdinalIgnoreCase))
                {
                    var authenticated = context.User is not null &&
                        context.User.Identity is not null
                        && context.User.Identity.IsAuthenticated;

                    if (!authenticated)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"SoapRequestMiddleware error : {ex.Message}");
                return;
            }

            await _next(context);
        }
    }
}
