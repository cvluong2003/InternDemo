namespace TrainModule2_New.Middleware
{
    public class CheckSerectCodeMiddleware
    {
        public readonly RequestDelegate _next;
        public CheckSerectCodeMiddleware(RequestDelegate next)
        {
             _next = next;  
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Serect-code") || string.IsNullOrEmpty(context.Request.Headers["Serect-code"]))
                {
                context.Response.StatusCode=StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid Key Serect-code in Request Header");
                return;     
            }
            await _next(context);
        }
    }
}
