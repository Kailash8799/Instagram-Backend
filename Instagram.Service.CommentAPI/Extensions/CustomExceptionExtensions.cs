using Instagram.Services.CommentAPI.Utils;

namespace Instagram.Service.CommentAPI.Extensions {
    public static class CustomExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
