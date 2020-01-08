namespace Application.Boundaries.Register
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<RegisterOutput>
    {
        /// <summary>
        /// Informs the user is already registered.
        /// </summary>
        /// <param name="message">Custom message.</param>
        void CustomerAlreadyRegistered(string message);
    }
}
