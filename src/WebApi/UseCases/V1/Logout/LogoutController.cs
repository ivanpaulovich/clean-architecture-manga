namespace WebApi.UseCases.V1.Logout
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class LogoutController : Controller
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [SuppressMessage("Security",
            "SCS0027:Open redirect: possibly unvalidated input in {1} argument passed to '{0}'",
            Justification = "<Pending>")]
        public async Task<IActionResult> Logout(Uri returnUrl)
        {
            await this.HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
                .ConfigureAwait(false);
            return this.Redirect(returnUrl.ToString());
        }
    }
}
