using System.Collections.Generic;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Img.Pack;

public partial class Image
{
    public static Images.LicenceImages ImageLogin = new()
    {
        Url = "URL=https://www.flaticon.com/packs/login-6",
        Images = new List<string>
        {
            "Login002-Unlock", "Login006-Lock-2", "Login003-Id-Card-1"
        }
    };
}