namespace WebApi.UseCases.V1.GetUserInfo
{
    using System.Security.Claims;

    /// <summary>
    ///
    /// </summary>
    public class UserInfo
    {
        private readonly ClaimsPrincipal _user;
        public UserInfo(ClaimsPrincipal user) => this._user = user;

        public string Name => this._user.FindFirst(ClaimTypes.Name).Value;
        public string Email => this._user.FindFirst(ClaimTypes.Email).Value;
        public string Image => this._user.FindFirst("image").Value;
    }
}
