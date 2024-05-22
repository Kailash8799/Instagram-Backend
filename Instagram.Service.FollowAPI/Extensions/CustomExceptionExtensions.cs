using Instagram.Services.FollowAPI.Utils;

namespace Instagram.Service.FollowAPI.Extensions {
    public static class CustomExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
