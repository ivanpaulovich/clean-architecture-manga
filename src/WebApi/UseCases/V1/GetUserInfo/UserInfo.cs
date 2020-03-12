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

        public string UserName
        {
            get
            {
                var name = this._user.FindFirst("name");
                if (name is Claim)
                    return name.Value;

                name = this._user.FindFirst(ClaimTypes.Name);
                return name.Value;
            }
        }
    }
}
