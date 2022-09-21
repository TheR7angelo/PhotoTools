using System.Collections.Generic;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Img.Pack;

public static partial class Image
{
    public static Images.LicenceImages ImageLogin = new()
    {
        Url = "https://www.flaticon.com/packs/login-6",
        Author = "Pixel perfect",
        Images = new List<string>
        {
            "Login002-Unlock", "Login006-Lock-2", "Login003-Id-Card-1"
        }
    };
}