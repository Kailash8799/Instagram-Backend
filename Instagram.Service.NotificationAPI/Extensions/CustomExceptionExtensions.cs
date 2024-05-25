using Instagram.Services.NotificationAPI.Utils;

namespace Instagram.Service.NotificationAPI.Extensions {
    public static class CustomExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
