namespace WebApi.UseCases.V1.SignUp
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The sign-up response.
    /// </summary>
    public sealed class SignUpCustomerResponse
    {
        /// <summary>
        ///     Instantiates the SignUpCustomerResponse.
        /// </summary>
        public SignUpCustomerResponse(UserModel userModel) => this.User = userModel;

        /// <summary>
        ///     Gets the user.
        /// </summary>
        [Required]
        public UserModel User { get; }
    }
}
