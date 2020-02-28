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
    public sealed class GoogleController : Controller
    {
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl) =>
            new ChallengeResult(
                GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = this.Url.Action(nameof(this.LoginCallback), new { returnUrl })
                });

        [HttpPost("LoginCallback")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCallback(string returnUrl)
        {
            var authenticateResult = await this.HttpContext
                .AuthenticateAsync("External")
                .ConfigureAwait(false);

            if (!authenticateResult.Succeeded)
                return this.BadRequest();

            var claimsIdentity = new ClaimsIdentity("Application");

            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Name));
            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Email));
            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst("image"));

            await this.HttpContext.SignInAsync(
                "Application",
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties { IsPersistent = true })
                .ConfigureAwait(false); // IsPersistent will set a cookie that lasts for two weeks (by default).

            return this.LocalRedirect(returnUrl);
        }

        [Authorize]
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            var user = new UserInfo(this.HttpContext.User);
            return this.Ok(user);
        }

        private class UserInfo
        {
            private readonly ClaimsPrincipal _user;
            public UserInfo(ClaimsPrincipal user) => this._user = user;

            public string Name => this._user.FindFirst(ClaimTypes.Name).Value;
            public string Email => this._user.FindFirst(ClaimTypes.Email).Value;
            public string Image => this._user.FindFirst("image").Value;
        }
    }
}
