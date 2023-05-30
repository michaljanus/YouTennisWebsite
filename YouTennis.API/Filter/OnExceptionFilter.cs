using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YouTennis.Base.Model;
using YouTennis.Core.Exception;

namespace YouTennis.API.Filter
{
    public class OnExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public OnExceptionFilter(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                return;
            }

            var exception = context.Exception;
            Error error;

            if (exception is NotFoundException)
            {
                error = new Error
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    StatusCode = 404
                };
            }
            else
            {
                error = new Error
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    StatusCode = 500
                };
            }
            context.HttpContext.Response.StatusCode = error.StatusCode;
            context.Result = new JsonResult(error.Message);

            base.OnException(context);
        }
    }
}
