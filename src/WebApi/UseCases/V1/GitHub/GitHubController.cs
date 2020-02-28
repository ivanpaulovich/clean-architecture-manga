namespace WebApi.UseCases.V1.Login
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication.Google;
    using System.Threading.Tasks;
    using System.Security.Claims;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class GitHubController : Controller
    {
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return this.Challenge(new AuthenticationProperties {RedirectUri = returnUrl});
        }
    }
}
