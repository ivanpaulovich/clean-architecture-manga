namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Security;

    /// <summary>
    ///     Debit.
    /// </summary>
    public sealed class UserModel
    {
        /// <summary>
        ///     Debit constructor.
        /// </summary>
        public UserModel(User user)
        {
            this.ExternalUserId = user.ExternalUserId.Text;
            this.UserId = user.UserId.Id;
        }

        [Required] public string ExternalUserId { get; }

        /// <summary>
        ///     Gets Amount.
        /// </summary>
        [Required]
        public Guid UserId { get; }
    }
}
