namespace WebApi.UseCases.V1.Login
{
    using System.Security.Claims;

    /// <summary>
    ///     User Info.
    /// </summary>
    public sealed class UserInfo
    {
        private readonly ClaimsPrincipal _user;

        /// <summary>
        ///     User Info constructor.
        /// </summary>
        public UserInfo(ClaimsPrincipal user) => this._user = user;

        /// <summary>
        ///     Get user name from string type name or from ClaimTypes.Name.
        /// </summary>
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
