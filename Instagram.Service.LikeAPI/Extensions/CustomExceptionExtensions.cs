using Instagram.Services.LikeAPI.Utils;

namespace Instagram.Service.LikeAPI.Extensions {
    public static class CustomExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
