namespace WebApi.Modules.Common
{
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    ///     Exception Filter.
    /// </summary>
    public sealed class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        ///     Add Problem Details when occurs Domain Exception.
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is DomainException))
            {
                return;
            }

            var problemDetails = new ProblemDetails
            {
                Status = 400, Title = "Bad Request", Detail = context.Exception.Message
            };

            context.Result = new BadRequestObjectResult(problemDetails);
            context.Exception = null;
        }
    }
}
