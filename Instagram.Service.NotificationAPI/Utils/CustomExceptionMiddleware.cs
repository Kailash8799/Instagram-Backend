﻿using Newtonsoft.Json;
using System.Net;

namespace Instagram.Services.NotificationAPI.Utils {
    public class CustomExceptionMiddleware {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next) {
            _next = next;
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
