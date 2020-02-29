namespace WebApi.UseCases.V1.GetUserInfo
{
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
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            var user = new UserInfo(this.HttpContext.User);
            return this.Ok(user);
        }
    }
}
