using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Instagram.Services.FollowAPI.Utils {
    public class CustomValidationFilter : IActionFilter {
        public void OnActionExecuting(ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                var errors = context.ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                .ToList();

                var errorDetails = ApiResponseHelper.CreateResponse(400, string.Join(", ", errors), false, "");
                context.Result = new BadRequestObjectResult(errorDetails);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) {
            if (!context.ModelState.IsValid) {
                var errors = context.ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                .ToList();

                var errorDetails = ApiResponseHelper.CreateResponse(400, string.Join(", ", errors), false, "");
                context.Result = new BadRequestObjectResult(errorDetails);
            }
        }
    }

}
