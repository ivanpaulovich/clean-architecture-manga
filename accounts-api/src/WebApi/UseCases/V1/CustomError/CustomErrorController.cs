namespace WebApi.UseCases.V1.CustomError
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     CustomError
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class CustomErrorController : Controller
    {
        /// <summary>
        ///     Get an custom error.
        /// </summary>
        /// <returns>The custom error model.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomError()
        {
            CustomErrorResponse model =
                new CustomErrorResponse {RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier};

            return this.View("~/UseCases/V1/CustomError/CustomError.cshtml", model);
        }
    }
}
