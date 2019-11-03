namespace WebApi.Filters
{
    using Domain;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;

    public sealed class BusinessExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = context.Exception.Message
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.Exception = null;
            }
        }
    }
}