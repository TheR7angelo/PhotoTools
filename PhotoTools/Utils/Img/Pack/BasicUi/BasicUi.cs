using System.Collections.Generic;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Img.Pack;

public static partial class Image
{
    public static Images.LicenceImages ImageBasicUi = new()
    {
        PackName = "BasicUi",
        Url = "https://www.flaticon.com/packs/basic-ui-3?word=basic%20ui",
        Author = "Pixel perfect",
        Images = new List<string>
        {
            "BasicUi008-Check", "BasicUi028-Download", "BasicUi050-Info", "BasicUi067-Plus", "BasicUi073-Question",
            "BasicUi076-Remove", "BasicUi089-Trash", "BasicUi090-Upload", "BasicUi091-Warning"
        }
        //todo correct BasicUi067-Plus and BasicUi089-Trash color
    };
}