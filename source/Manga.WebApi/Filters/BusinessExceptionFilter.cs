namespace Manga.WebApi.Filters
{
    using Manga.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public sealed class BusinessExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            DomainException domainException = context.Exception as DomainException;
            if (domainException != null)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = domainException.Message
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.Exception = null;
            }
        }
    }
}
