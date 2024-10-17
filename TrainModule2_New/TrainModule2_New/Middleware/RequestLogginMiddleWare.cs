using System.Diagnostics;

namespace TrainModule2_New.Middleware
{
    public class RequestLogginMiddleWare
    {
        private readonly ILogger<RequestLogginMiddleWare> _logger;
        private readonly RequestDelegate _next;
        public RequestLogginMiddleWare (ILogger<RequestLogginMiddleWare> logger,RequestDelegate next)
        {   
            _logger = logger;
            _next = next;
        }
        public async Task Invoke (HttpContext context)
        {
            var stopWatch= Stopwatch.StartNew();
            _logger.LogInformation("Receive Request from : {ulr} with method {method}",context.Request.Path,context.Request.Method);
            _logger.LogInformation("LogMiddleWare[Before]");
            await _next(context);
            stopWatch.Stop();
            _logger.LogInformation("Response Status is :{status} complete in {time} ms",context.Response.StatusCode,stopWatch.ElapsedMilliseconds);
            _logger.LogInformation("LogMiddleWare[After]");

        }
    }
}
