namespace WebApi.UseCases.V1.GitHub
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class LoginController : Controller
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet("GitHub")]
        [AllowAnonymous]
        public IActionResult GitHub(string? returnUrl = "https://localhost:5001/")
        {
            return new ChallengeResult(
                "GitHub",
                new AuthenticationProperties
                {
                    RedirectUri = returnUrl
                });
        }
    }
}
