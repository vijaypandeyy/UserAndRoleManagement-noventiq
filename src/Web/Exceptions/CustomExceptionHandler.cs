using Application.Models.Common;
using Core;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Web.Exceptions
{
    public static class CustomExceptionHandler
    {
        public static void USeCustomErrors(this IApplicationBuilder app)
        {
            app.Use(async delegate (HttpContext context, Func<Task> next)
            {
                try
                {
                 var error=   context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    await WriteResponse(context, error);
                }
                catch (Exception ex)
                {
                    await WriteResponse(context, ex);
                }
            });

        }


        private static Task WriteResponse(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            var res = Result<string>.ServerError(new List<string>
                {   exception.Message,
                    exception.StackTrace
            });

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(res, options);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(jsonString);
        }
    }
}
