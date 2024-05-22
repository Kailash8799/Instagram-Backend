namespace Instagram.Services.LikeAPI.Utils {
    public class ApiResponseHelper {
        public static ApiResponse<T> CreateResponse<T>(int statusCode, string message, bool success, T data) {
            return new ApiResponse<T> {
                StatusCode = statusCode,
                Message = message,
                Success = success,
                Data = data
            };
        }
    }
}
