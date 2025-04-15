using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace MoviesSearch.Api.Middlewares
{
    public static class BuiltInExceptionHandler
    {
        public static void AddErrorHandler(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(appError => {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature != null) {
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(
                            new {
                                StatusCode=context.Response.StatusCode,
                                message="something went wrong"
                    })
                    );
                    }
                });
            });
        }

    }
}
