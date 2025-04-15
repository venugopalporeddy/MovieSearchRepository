using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace MoviesSearch.Api.Middlewares
{
    public class CustomErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomErrorMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext) 
        {
            try
            {
                await _next(httpcontext);
            }
            catch (Exception ex) {
                await HandleExceptionAsync(httpcontext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception) 
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            if (exception is IndexOutOfRangeException err)
            {
               // context.Response.StatusCode = (int)err.HttpStatusCode.Value,

                await context.Response.WriteAsync(JsonConvert.SerializeObject(
                    new
                    {
                       
                        message = "index was out of range"
                    })
            );
            }
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = exception.GetType().Name, // Type of exception (e.g., IndexOutOfRangeException)
                message = exception.Message,     // Exception message
                stackTrace = exception.StackTrace // Stack trace (optional)
            }));

        }

    }

    public static class RequestResponseMiddlewareExtensions
    {
        public static IApplicationBuilder CallResponseMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorMiddleware>();
        }
    }
}
