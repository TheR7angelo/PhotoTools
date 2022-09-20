using System.Collections.Generic;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Img.Pack;

public partial class Image
{
    // todo make list for login
    private Images.LicenceImages _imageBasicUi = new()
    {
        Url = "https://www.flaticon.com/packs/basic-ui-3?word=basic%20ui",
        Images = new List<string>
        {
            "BasicUi008-Check", "BasicUi050-Info", "BasicUi067-Plus", "BasicUi073-Question", "BasicUi076-Remove",
            "BasicUi089-Trash", "BasicUi091-Warning"
        }
    };
}