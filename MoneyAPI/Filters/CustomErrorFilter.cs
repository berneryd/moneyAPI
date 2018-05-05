using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MoneyAPI.Filters
{
    public class CustomErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) {
            ApiError apiError = null;
            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                context.Exception = null;
                apiError = new ApiError(ex.Message);

                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;

                apiError = new ApiError(msg);
                apiError.detail = stack;

                context.HttpContext.Response.StatusCode = 500;
            }

            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}