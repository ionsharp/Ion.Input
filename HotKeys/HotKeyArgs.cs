namespace Ion.Input.Global.HotKeys;

/// <summary>
/// The event arguments passed when a HotKeySet's OnHotKeysDownHold event is triggered.
/// </summary>
///<remarks>
/// Creates an instance of the HotKeyArgs.
/// <param name="triggeredAt">Time when the event was triggered</param>
///</remarks>
public sealed class HotKeyArgs(DateTime TriggeredAt) : EventArgs
{
    private readonly DateTime time = TriggeredAt;
    /// <summary>
    /// Time when the event was triggered
    /// </summary>
    public DateTime Time
    {
        get
        {
            return time;
        }
    }
}
