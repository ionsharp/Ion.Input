using System.Runtime.InteropServices;

namespace Ion.Input.Global.WinApi;

/// <summary>
/// The Point structure defines the X- and Y- coordinates of a point. 
/// </summary>
/// <remarks>
/// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/rectangl_0tiq.asp
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct Point(int x, int y)
{
    /// <summary>
    /// Specifies the X-coordinate of the point. 
    /// </summary>
    public int X = x;
    /// <summary>
    /// Specifies the Y-coordinate of the point. 
    /// </summary>
    public int Y = y;

    public static bool operator ==(Point a, Point b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }

    public readonly bool Equals(Point other)
    {
        return other.X == X && other.Y == Y;
    }

    public override readonly bool Equals(object obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != typeof(Point)) return false;
        return Equals((Point)obj);
    }

    public override readonly int GetHashCode()
    {
        unchecked
        {
            return (X * 397) ^ Y;
        }
    }
}