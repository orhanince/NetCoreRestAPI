
namespace NetCoreRestAPI.Middleware
{
    public class CustomUnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomUnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Call the next middleware in the pipeline
            await _next(context);

            // Check if the response status code is 401 Unauthorized
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                context.Response.ContentType = "application/json";
                var jsonResponse = new { message = "Unauthorized: Access is denied due to invalid credentials." };
                await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(jsonResponse));
            }
        }
    }
}
