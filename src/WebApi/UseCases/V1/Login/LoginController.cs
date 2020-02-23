namespace WebApi.UseCases.V1.Login
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Login
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [AllowAnonymous]
    [Route("[controller]")]
    public sealed class LoginController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return this.Challenge(new AuthenticationProperties {RedirectUri = returnUrl});
        }
    }
}
