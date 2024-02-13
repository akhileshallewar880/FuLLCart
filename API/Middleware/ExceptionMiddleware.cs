using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next1;
        private readonly ILogger<ExceptionMiddleware> logger1;
        private readonly IHostEnvironment env1;

        // Constructor for ExceptionMiddleware
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            next1 = next;
            logger1 = logger;
            env1 = env;
        }

        // Middleware pipeline execution method
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass the HTTP context to the next middleware in the pipeline
                await next1(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                logger1.LogError(ex, ex.Message);

                // Set response content type to JSON and status code to 500 (Internal Server Error)
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Create ApiException object based on environment
                var response = env1.IsDevelopment()
                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

                // Configure JSON serialization options
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                // Serialize ApiException object to JSON
                var json = JsonSerializer.Serialize(response, options);

                // Write JSON response to the HTTP response body
                await context.Response.WriteAsync(json);
            }
        }
    }
}
