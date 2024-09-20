using System.Text.Json;

namespace NetCoreRestAPI.Middleware
{
    public class GlobalResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next middleware in the pipeline
            await _next(context);

            // Format the response
            context.Response.ContentType = "application/json";

            // Handle errors globally
            if (context.Response.StatusCode >= 400)
            {
                var response = new
                {
                    Success = false,
                    ErrorMessage = "An error occurred."
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
