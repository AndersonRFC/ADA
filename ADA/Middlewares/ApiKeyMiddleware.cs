namespace Web.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var apiKeyHeader = context.Request.Headers["x-Key"];

        if(apiKeyHeader.Count == 0 || apiKeyHeader[0] != "antss")
        {
            context.Response.StatusCode = 401;
            return;
        }

        await _next(context);
    }
}
