using Microsoft.AspNetCore.Authentication;
using System.Net;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AspNetCoreSoapAuthBasicService.Middlewares
{
    public class AuthenticationBasicMiddleware
    {

        private readonly RequestDelegate _next;

        public AuthenticationBasicMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var test = context.Request.Headers["Authorization"];
                    var test2 = 123;

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync($"test test");
                    return;
                }
                else
                {
                    context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    return;
                }

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Une erreur s'est produite : {ex.Message}");
                return;
            }

            // Passer la requête au prochain middleware dans le pipeline
            await _next(context);
        }
    }
}
