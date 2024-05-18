using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Instagram.Services.PostAPI.Utils {
    public class CustomExceptionMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch (Exception ex) {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = ApiResponseHelper.CreateResponse(context.Response.StatusCode, exception.Message.ToString(), false, "");

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
        }
    }

}
