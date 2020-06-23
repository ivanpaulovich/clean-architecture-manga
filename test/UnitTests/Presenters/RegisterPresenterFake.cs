namespace UnitTests.Presenters
{
    using Application.Boundaries.Register;

    /// <summary>
    /// </summary>
    public sealed class RegisterPresenterFake : IRegisterOutputPort
    {
        /// <summary>
        /// </summary>
        public RegisterOutput? StandardOutput { get; private set; }

        /// <summary>
        /// </summary>
        public RegisterOutput? AlreadyRegisteredOutput { get; private set; }

        /// <summary>
        /// </summary>
        public string? ErrorOutput { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(RegisterOutput output) => this.StandardOutput = output;

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void HandleAlreadyRegisteredCustomer(RegisterOutput output) => this.AlreadyRegisteredOutput = output;

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
