using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoTools.Utils.Function;

public static partial class Convert
{
    public static ImageSource ParseToImageSource(this Bitmap bitmap) => Imaging.CreateBitmapSourceFromHBitmap
        (bitmap.GetHbitmap(), IntPtr.Zero,Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

    public static Icon ParseToIcon(this Bitmap bitmap) => Icon.FromHandle(bitmap.GetHbitmap());
}