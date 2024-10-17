using Newtonsoft.Json.Linq;
namespace TrainModule2_New.Middleware
{
    public class CheckNamSinhMiddleWare
    {
        private readonly RequestDelegate _next;
        public CheckNamSinhMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public void Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8, leaveOpen: true))
            {
                var RequestBodyAsText = reader.ReadToEnd();

            }
        }
    }
}
