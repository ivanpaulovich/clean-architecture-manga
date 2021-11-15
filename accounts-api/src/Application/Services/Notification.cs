namespace Application.Services;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// </summary>
public sealed class Notification
{
    /// <summary>
    ///     Error message.
    /// </summary>
    private readonly IDictionary<string, IList<string>> _errorMessages = new Dictionary<string, IList<string>>();

    public IDictionary<string, string[]> ModelState
    {
        get
        {
            Dictionary<string, string[]> modelState = this._errorMessages
                .ToDictionary(item => item.Key, item => item.Value.ToArray());

            return modelState;
        }
    }


    /// <summary>
    ///     Returns true when it does not contains error messages.
    /// </summary>
    public bool IsValid => this._errorMessages.Count == 0;

    public bool IsInvalid => this._errorMessages.Count > 0;

    /// <summary>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="message"></param>
    public void Add(string key, string message)
    {
        if (!this._errorMessages.ContainsKey(key))
        {
            this._errorMessages[key] = new List<string>();
        }

        this._errorMessages[key].Add(message);
    }
}
