using Ion.Input.Global.WinApi;

namespace Ion.Input.Global.HotKeys;

/// <summary>
/// A very thin wrapper around the KeyboardHookListener that provides everything the KeyboardHookListener does but adds the ability to 
/// add and hotswap HotKeySets in order to build a HotKey system around a Hooker.
/// </summary>
///<remarks>
/// Creates an instance of the HotKeySetsListener, which attaches a Hot Key system to the Hooker selected.
///</remarks>
///<param name="hksCollection">A collection of HotKeySets</param>
///<param name="hooker">Depending on this parameter the listener hooks either application or global keyboard events.</param>
///<remarks>Hooks are not active after instantiation. You need to use either <see cref="ListenerBase.Enabled"/> property or call <see cref="ListenerBase.Start"/> method.</remarks>
public class HotKeySetsListener(HotKeySetCollection hksCollection, Hooker hooker) : ListenerKeyboard(hooker)
{
    private readonly HotKeySetCollection m_hksCollection = hksCollection;

    /// <summary>
    /// This method processes the data from the hook and initiates event firing.
    /// </summary>
    /// <param name="wParam">The first Windows Messages parameter.</param>
    /// <param name="lParam">The second Windows Messages parameter.</param>
    /// <returns>
    /// True - The hook will be passed along to other applications.
    /// <para>
    /// False - The hook will not be given to other applications, effectively blocking input.
    /// </para>
    /// </returns>
    protected override bool ProcessCallback(int wParam, nint lParam)
    {

        KeyEventArgsExt e = KeyEventArgsExt.FromRawData( wParam, lParam, IsGlobal );
        m_hksCollection.OnKey(e);

        //Can bypass the base by setting the 3 Invoke methods to protected, which will reduce having to create KeyEventArgsExt twice.
        return base.ProcessCallback(wParam, lParam);

    }

    /// <summary>
    /// Gets the HotKeySetCollection attached to the listener
    /// </summary>
    public HotKeySetCollection HotKeyCollection
    {
        get { return m_hksCollection; }
    }
}
