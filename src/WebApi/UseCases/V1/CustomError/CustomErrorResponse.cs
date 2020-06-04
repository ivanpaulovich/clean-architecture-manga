namespace WebApi.UseCases.V1.CustomError
{
    /// <summary>
    /// </summary>
    public sealed class CustomErrorResponse
    {
        public string RequestId { get; set; } = string.Empty;
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
