using Instagram.Services.MediaAPI.Utils;

namespace Instagram.Service.MediaAPI.Extensions {
    public static class CustomExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
