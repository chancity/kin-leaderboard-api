using System;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;
using kin_leaderboard_frontend.Shared.Models.ApiResponse;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace kin_leaderboard_api.Exceptions
{
    public class ApiExceptionMiddleware
    {
        private readonly ILogger<ApiExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<ApiExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseApiException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning(
                        "The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected
            string message = exception.Message.Replace("/", "");

            if (exception is NotFoundApiException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (exception is DbException)
            {
                //message = "DbException, apiError in logs";
                code = HttpStatusCode.InternalServerError;
            }
            else if (exception is BadRequestApiException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (exception is UnauthorizedApiException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (exception is RateLimitApiException)
            {
                code = HttpStatusCode.SeeOther;
            }

            string result =
                JsonConvert.SerializeObject(
                    new BaseResponse(new ApiError(message, exception?.StackTrace)));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code != HttpStatusCode.SeeOther ? (int) code : 429;
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}