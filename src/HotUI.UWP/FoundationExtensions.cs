using System.Drawing;
using System.Numerics;
using UWPSize = Windows.Foundation.Size;
using UWPRect = Windows.Foundation.Rect;

namespace HotUI.UWP
{
    public static class FoundationExtensions
    {
        public static SizeF ToSizeF(this Vector2 size)
        {
            return new SizeF((float)size.X, (float)size.Y);
        }

        public static SizeF ToSizeF(this UWPSize size)
        {
            return new SizeF((float) size.Width, (float) size.Height);
        }

        public static UWPSize ToSize(this SizeF size)
        {
            return new UWPSize((float)size.Width, (float)size.Height);
        }

        public static UWPRect ToRect(this RectangleF rect)
        {
            return new UWPRect(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}