using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_API.Filters
{
    public class NotFoundFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is KeyNotFoundException keyNotFoundException)
            {
                context.Result = new NotFoundObjectResult(keyNotFoundException.Message);
                context.ExceptionHandled = true;
            }
        }
    }
}
