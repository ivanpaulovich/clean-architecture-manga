namespace WebApi.UseCases.V1.Register
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The response for Registration.
    /// </summary>
    public sealed class RegisterResponse
    {
        /// <summary>
        ///     The Response Registration Constructor.
        /// </summary>
        public RegisterResponse(
            CustomerModel customerModel,
            List<AccountModel> accountsModel)
        {
            this.Customer = customerModel;
            this.Accounts = accountsModel;
        }

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }

        /// <summary>
        ///     Gets accounts.
        /// </summary>
        [Required]
        public List<AccountModel> Accounts { get; }
    }
}
