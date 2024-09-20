namespace NetCoreRestAPI.Middleware
{
    public class CustomForbiddenMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomForbiddenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\": \"Access Denied: You do not have permission to access this resource.\"}");
            }
        }
    }
}
