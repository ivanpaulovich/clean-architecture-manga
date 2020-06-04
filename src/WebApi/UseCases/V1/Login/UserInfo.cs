namespace WebApi.UseCases.V1.Login
{
    using System.Security.Claims;

    /// <summary>
    /// </summary>
    public sealed class UserInfo
    {
        private readonly ClaimsPrincipal _user;
        public UserInfo(ClaimsPrincipal user) => this._user = user;

        public string UserName
        {
            get
            {
                Claim name = this._user.FindFirst("name");
                if (name != null)
                {
                    return name.Value;
                }

                name = this._user.FindFirst(ClaimTypes.Name);
                return name.Value;
            }
        }
    }
}
