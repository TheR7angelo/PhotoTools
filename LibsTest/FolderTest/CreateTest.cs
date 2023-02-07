using Libs.Folder;
using WindowsShortcutFactory;

namespace LibsTest.FolderTest;

public class CreateTest
{
    [Fact]
    private async void CreateFolderTest()
    {
        var path = Path.GetFullPath("LibsTest/Dossier Test");

        var cancellationTokenSource = new CancellationTokenSource();
        
        var middleFolder = new List<string> { "1_Original", "2_Traitement" };

        var task = path.CreateFolder(2023, middleFolder, cancellationTokenSource.Token);
        await task;
    }
    
    [Fact]
    private void CreateSortCut()
    {
        const string target = "C:\\Users\\ZP6177\\Downloads\\df.csv";
        const string file = "C:\\Users\\ZP6177\\Creative Cloud Files\\Programmation\\C#\\Personnel\\PhotoTools\\LibsTest\\test.lnk";
        using var shortcut = new WindowsShortcut
        {
            Path = target
        };
        shortcut.Save(file);
    }
}