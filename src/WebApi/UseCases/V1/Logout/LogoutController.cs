namespace WebApi.UseCases.V1.Logout
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication.Google;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    ///
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class LogoutController : Controller
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.HttpContext
                .SignOutAsync()
                .ConfigureAwait(false);
            return this.Redirect("/swagger/index.html");
        }
    }
}
